using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;

namespace PluginInsViviendas_UNO.Controlador
{
    public class MetodosPlano
    {
        public static bool SeleccionaEntidadTipo(String msg, out ObjectId id, params Type[] tps)
        {
            id = new ObjectId();
            Boolean flag = false;

            PromptEntityOptions opt = new PromptEntityOptions(msg);
            if (tps.Length > 0)
            {
                opt.SetRejectMessage("No es del tipo solicitado");
                foreach (Type tp in tps)
                    opt.AddAllowedClass(tp, true);
            }
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptEntityResult res = ed.GetEntity(opt);

            if (res.Status == PromptStatus.OK)
            {
                flag = true;
                id = res.ObjectId;

            }
            return flag;
        }

        internal static bool ValidaFormato(DataGridView dtOrdenaViv)
        {
            bool flag = true;
            int res = new int();

            foreach (DataGridViewRow dtrow in dtOrdenaViv.Rows)
            {
                if (!string.IsNullOrEmpty((dtrow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Value ?? "").ToString()) &&
                    !string.IsNullOrWhiteSpace((dtrow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Value ?? "").ToString()))
                {
                    if (!int.TryParse(dtrow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Value.ToString(), out res))
                    {
                        flag = false;
                        dtrow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Style.BackColor = System.Drawing.Color.FromArgb(168, 168, 168);
                    }
                }
                else
                {
                    flag = false;
                    dtrow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Style.BackColor = System.Drawing.Color.FromArgb(168, 168, 168);
                }
            }

            return flag;
        }

        public static bool SelMultipleViviendas(out ObjectIdCollection ids, params Type[] tps)
        {
            ids = new ObjectIdCollection();


            TypedValue[] FilType = new TypedValue[1];
            FilType.SetValue(new TypedValue((int)DxfCode.Start, RXObject.GetClass(typeof(Polyline)).DxfName), 0);

            SelectionFilter SelFilter = new SelectionFilter(FilType);

            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            
            //Resultado
            PromptSelectionResult res = ed.GetSelection(SelFilter);

            if (res.Status == PromptStatus.OK)
            {
                ids = new ObjectIdCollection(res.Value.GetObjectIds());

            }
            return ids.Count > 0;

        }

        public static Entity AbrirEntidad(ObjectId entId)
        {
            Entity ent = null;
            Document doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            //Abrimos la BD y el editor

            Database dwg = doc.Database;
            Editor ed = doc.Editor;
            //En la BD se encuentra el transaction manager que se encarga de 
            //controlar todas las transacciones
            using (Transaction tr = dwg.TransactionManager.StartTransaction())
            {
                try
                {
                    ent = entId.GetObject(OpenMode.ForRead) as Entity;
                    tr.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception exc)
                {
                    //Se deshace lo que sale mla en la transacción
                    //El abort lo destruye
                    ed.WriteMessage(exc.Message);
                    tr.Abort();
                }
            }

            return ent;
        }

        public static Point3dCollection ExtraerVertices(ObjectId plId)
        {
            Point3dCollection pts = new Point3dCollection();

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //Abrimos la BD y el editor

            Database dwg = doc.Database;
            Editor ed = doc.Editor;
            //En la BD se encuentra el transaction manager que se encarga de 
            //controlar todas las transacciones
            using (Transaction tr = dwg.TransactionManager.StartTransaction())
            {
                try
                {
                    Polyline pl = plId.GetObject(OpenMode.ForRead) as Polyline;
                    for (int i = 0; i < pl.NumberOfVertices; i++)
                    {
                        pts.Add(pl.GetPoint3dAt(i));

                    }
                    tr.Commit();
                }
                catch (Autodesk.AutoCAD.Runtime.Exception exc)
                {
                    //Se deshace lo que sale mla en la transacción
                    //El abort lo destruye
                    ed.WriteMessage(exc.Message);
                    tr.Abort();
                }
            }

            return pts;
        }

        public static ObjectIdCollection TomarEntidadLayer(string layerName, Point3d ptmin, Point3d ptmax, out string msjerror)
        {

            msjerror = "";
            string entLayer = "";
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectIdCollection IdsGenerales= new ObjectIdCollection();
            ObjectIdCollection IdsFinal = new ObjectIdCollection();
            PromptSelectionResult psr;
            Entity ent;


            TypedValue[] tvs = new TypedValue[2]
                            {
                                new TypedValue((int)DxfCode.LayerName, layerName),
                                new TypedValue( (int)DxfCode.Start, RXClass.GetClass(typeof(DBText)).DxfName)
                            };
            SelectionFilter sf = new SelectionFilter(tvs);

            psr = ed.SelectWindow(ptmin, ptmax, sf);
            //Valida que el filtro funcione con palabra exacta
            if (psr.Status == PromptStatus.OK)
            {
                IdsFinal = new ObjectIdCollection(psr.Value.GetObjectIds());
                return IdsFinal;
            }
            //Valida que no sea error por mayusculas o espacios
            else if (psr.Status == PromptStatus.Error)
            {                
                psr = ed.SelectWindow(ptmin, ptmax);
                if (psr != null)
                {                    
                    IdsGenerales = new ObjectIdCollection(psr.Value.GetObjectIds());
                }
                else
                {                    
                    IdsGenerales = new ObjectIdCollection();
                }

                foreach (ObjectId objid in IdsGenerales)
                {                                   
                    ent = AbrirEntidad(objid) as Entity;
                    entLayer = (ent.Layer.ToUpper().Replace(" ", string.Empty));

                    if (entLayer == (layerName.ToUpper().Replace(" ", string.Empty)) && ent.GetType().Name == "DBText")
                    {
                        IdsFinal.Add(objid);
                    }
                }
                if (IdsFinal.Count == 0)
                {
                    msjerror = "Falta configurar la Capa: " + layerName;
                }

                return IdsFinal;
            }
            else
            {
                msjerror = "Falta configurar la Capa: "+layerName;
                return IdsFinal;
            }
        }

        public static ObjectIdCollection TomarEntidadLayer(string layerName, Point3dCollection pts, out string msjerror)
        {

            msjerror = "";
            string entLayer = "";
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectIdCollection IdsGenerales = new ObjectIdCollection();
            ObjectIdCollection IdsFinal = new ObjectIdCollection();
            PromptSelectionResult psr;
            Entity ent;


            TypedValue[] tvs = new TypedValue[2]
                            {
                                new TypedValue((int)DxfCode.LayerName, layerName),
                                new TypedValue( (int)DxfCode.Start, RXObject.GetClass(typeof(DBText)).DxfName)
                            };
            SelectionFilter sf = new SelectionFilter(tvs);
            
            psr = ed.SelectWindowPolygon(pts, sf);
            //Valida que el filtro funcione con palabra exacta
            if (psr.Status == PromptStatus.OK)
            {                 
                IdsFinal = new ObjectIdCollection(psr.Value.GetObjectIds());
                return IdsFinal;
            }
            //Valida que no sea error por mayusculas o espacios
            else if (psr.Status == PromptStatus.Error)
            {                
                psr = ed.SelectWindowPolygon(pts);
                if (psr != null)
                    if(psr.Value != null)
                        IdsGenerales = new ObjectIdCollection(psr.Value.GetObjectIds());
                else
                    IdsGenerales = new ObjectIdCollection();

                foreach (ObjectId objid in IdsGenerales)
                {
                    ent = AbrirEntidad(objid) as Entity;
                    entLayer = (ent.Layer.ToUpper().Replace(" ", string.Empty));
                    if (entLayer == (layerName.ToUpper().Replace(" ", string.Empty)) && ent.GetType().Name == "DBText")
                    {
                        IdsFinal.Add(objid);
                    }
                }
                if (IdsFinal.Count == 0)
                {
                    msjerror = "Falta configurar la Capa: " + layerName;
                }

                return IdsFinal;
            }
            else
            {                
                msjerror = "Falta configurar la Capa: " + layerName;
                return IdsFinal;
            }
        }

        public static ObjectIdCollection TomarViviendasLayer(string layerName, Point3d min, Point3d max, out string msjerror)
        {

            msjerror = "";            
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectIdCollection IdsGenerales = new ObjectIdCollection();
            ObjectIdCollection IdsFinal = new ObjectIdCollection();
            PromptSelectionResult psr;
            Entity ent;


            TypedValue[] tvs = new TypedValue[1]
                            {                                
                                new TypedValue( (int)DxfCode.Start, RXClass.GetClass(typeof(Polyline)).DxfName)
                            };
            SelectionFilter sf = new SelectionFilter(tvs);

            psr = ed.SelectWindow(min,max, sf);

            //Valida que el filtro funcione únicamente con Polilíneas
            if (psr.Status == PromptStatus.OK)
            {
                IdsGenerales = new ObjectIdCollection(psr.Value.GetObjectIds());

                foreach(ObjectId objid in IdsGenerales)
                {
                    //Entidad
                    ent = AbrirEntidad(objid) as Entity;
                    
                    if (ent.Layer.Length >= layerName.Length)
                    {
                        //Reviso que las layer contenga el nombre SMB_CONSTRUCCIONES
                        if (ent.Layer.Substring(0, layerName.Length).ToUpper().Replace(" ", string.Empty) == layerName)
                        {
                            IdsFinal.Add(objid);
                        }
                    }
                }

                return IdsFinal;
            }
            else
            {
                msjerror = "Hubo problema en la selección de viviendas del layer " + layerName;
                return IdsFinal;
            }
        }

        public static ObjectIdCollection TomaNoOficialLayer(Polyline pl, String layerName, double factor)
        {
            ObjectIdCollection IdsFinales = new ObjectIdCollection();
            ObjectIdCollection IdsGenerales = new ObjectIdCollection();
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            string entLayer;
            //1: Seleccionar la poli-línea en lugar de pasar los vértices, el problema que usas first() de tu colección de puntos y Last().
            //Los puntos no están ordenados, debes definir si los ordenas por X, Y, de la manera que los pasas no garantiza que sea el mínimo y el máximo
            //para eso usar GeometricExtents de las entidades

                        //La polilínea debe estar en la capa deseada
                       // if (pl.Layer == layername)
                        //{
                            //Obtengo el mínimo y el máximo
                            Point3d min = pl.GeometricExtents.MinPoint, max = pl.GeometricExtents.MaxPoint;
                            //Escalo los puntos tomando como punto de referencia el punto medio, el tema es escalar usando una transformada
                            //geometrica. 
                            Point3d middle = new Point3d((min.X + max.X) / 2, (min.Y + max.Y) / 2, 0);  //No importa Z es plana(XY) la polilínea
                            Matrix3d matrix = Matrix3d.Scaling(factor, middle);
                            min = min.TransformBy(matrix);
                            max = max.TransformBy(matrix);
                            //Con los puntos escalados genero la ventana y uso un filtro de selección que solo pase textos
                            TypedValue[] tvs = new TypedValue[2]
                            {
                                new TypedValue((int)DxfCode.LayerName, layerName),
                                new TypedValue( (int)DxfCode.Start, RXClass.GetClass(typeof(DBText)).DxfName)
                            };


                            //// Get the current document and database

                            //Document acDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;

                            //acDoc.LockDocument();
                            //Database acCurDb = acDoc.Database;
                            //// Start a transaction

                            //using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
                            //{

                            //    // Open the Block table for read

                            //    BlockTable acBlkTbl;

                            //    acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,

                            //                                 OpenMode.ForRead) as BlockTable;



                            //    // Open the Block table record Model space for write

                            //    BlockTableRecord acBlkTblRec;

                            //    acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],

                            //                                    OpenMode.ForWrite) as BlockTableRecord;



                            //    // Create a line that starts at 5,5 and ends at 12,3

                            //    Line acLine = new Line(min, max);

                            //    acLine.SetDatabaseDefaults();



                            //    // Add the new object to the block table record and the transaction

                            //    acBlkTblRec.AppendEntity(acLine);

                            //    acTrans.AddNewlyCreatedDBObject(acLine, true);



                            //    // Save the new object to the database

                            //    acTrans.Commit();

                            //}

                            SelectionFilter sf = new SelectionFilter(tvs);  

                            PromptSelectionResult SelLayer = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.
                                                            Editor.SelectWindow(min, max, sf);
                            
                            if (SelLayer.Status == PromptStatus.OK)
                            {
                                IdsFinales = new ObjectIdCollection(SelLayer.Value.GetObjectIds());
                                return IdsFinales;
                            }

                            else if (SelLayer.Status == PromptStatus.Error)
                            {
                                SelLayer = ed.SelectWindow(min, max);
                                if (SelLayer != null)
                                    if(SelLayer.Value != null)
                                       IdsGenerales = new ObjectIdCollection(SelLayer.Value.GetObjectIds());
                                    else
                                       IdsGenerales = new ObjectIdCollection();
                                else
                                    IdsGenerales = new ObjectIdCollection();

                                foreach (ObjectId objid in IdsGenerales)
                                {
                                    Entity ent = AbrirEntidad(objid) as Entity;
                                    entLayer = (ent.Layer.ToUpper().Replace(" ", string.Empty));
                                    layerName = (layerName.ToUpper().Replace(" ", string.Empty));
                                    if (entLayer == layerName && ent.GetType().Name == "DBText")
                                    {
                                        IdsFinales.Add(objid);
                                    }
                                }

                                return IdsFinales;
                            }

                            else
                            {
                                return IdsFinales;
                            }
        }

        public static string EnviaFormatoArea(string decimales)
        {
            String StFormato = "";

            switch (decimales)
            {
                case "1":
                    StFormato = "{0:N1}";
                    break;
                case "2":
                    StFormato = "{0:N2}";
                    break;
                case "3":
                    StFormato = "{0:N3}";                        
                    break;
                case "4":
                    StFormato = "{0:N4}";
                    break;
                default:
                    StFormato = "{0:N2}";
                    break;
                    
            }
            return StFormato;
        }

        public static bool ValidaNoRepetirVivienda(ObjectId Id, DataGridView dtDatosP)
        {
            bool flag = true;

            string idPolilinea = "";
            List<int> list = new List<int>();

            idPolilinea = Id.ToString();

            for (int i = dtDatosP.Rows.Count - 1; i >= 0; i--)
            {
                string idActual = "";
                if (dtDatosP.Rows[i].Cells[Modelo.IndexColumn.USDPColumnaIDs].Value != null)
                    idActual = dtDatosP.Rows[i].Cells[Modelo.IndexColumn.USDPColumnaIDs].Value.ToString();

                if (string.Equals(idActual, idPolilinea))
                {
                  flag = false;
                  dtDatosP.Rows.RemoveAt(i);
                }
            }

            return flag;
        }

        public static bool ValidaNoRepetir(double dato, List<double> Lista)  //Regresa true cuando el dato enviado es distinto 
                                                                                //de cualquiera de la lista
        {
            Boolean flag = true;
            //ArrayList listaIds = new ArrayList()

            foreach (double datolista in Lista)
            {

                if (datolista == dato)
                {
                    flag = false;
                    break;
                }
                else if (datolista != dato)
                {
                    flag = true;
                }

            }
            return flag;
        }

        public static void RevisoDatosSeleccionados(DataGridView dtDatosPlano, string TipoCarga, out bool ErrorTipoDato, out bool ErrorVacio)
        {

            ErrorTipoDato = false;
            ErrorVacio = false;

            //Inicializo arr 2 dimensiones para almacenar viviendas
            Modelo.EncDatosPlano.VivsSeleccionPlano = new string[dtDatosPlano.RowCount, dtDatosPlano.ColumnCount];

            //Limpio M2 de Superpficie Lote Tipo
            Modelo.EncDatosPlano.M2SuperFloteTipo.Clear();

            if (TipoCarga == "Unifamiliar")
            {
                #region Unifamiliar
                for (int rows = 0; rows < dtDatosPlano.Rows.Count; rows++)
                {
                    for (int col = 0; col < dtDatosPlano.Rows[rows].Cells.Count; col++)
                    {
                        //Inicializo
                        string value = "";
                        
                        //Envío a blanco columnas
                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.White;

                        value = (dtDatosPlano.Rows[rows].Cells[col].Value ?? "").ToString();

                        switch (col)
                        {
                            //Celda IDS--------------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaIDs:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;
                            //------------------------------------------------------------------------------------------
                            
                            //Manzana-----------------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaManzana:
                                //Validamos que el dato no este vacío
                                if (value != "")
                                {
                                    int ManzanaFinal = new int();

                                    //Valida que el dato sea de tipo entero
                                    bool EsNumManzana = int.TryParse(value, out ManzanaFinal);

                                    //Si es Entero                                    
                                    if (EsNumManzana == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    //En dado caso que no sea entero lo muestra en gris
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true; //Envío señal de no avanzar
                                    }
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;//Envío señal de no avanzar
                                }
                                break;
                            //------------------------------------------------------------------------------------------

                            //Lote Final--------------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaLote:
                                //Validamos que el dato no este vacío
                                if (value != "")
                                {
                                    int LoteFinal = new int();

                                    bool EsNumLote = int.TryParse(value, out LoteFinal);

                                    if (EsNumLote == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;
                            //------------------------------------------------------------------------------------------

                            //Numero Oficial----------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaNoOficial:
                                //No se realiza validación ya que es alfanumerico
                                Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;
                            //-------------------------------------------------------------------------------------------

                            //Numero Interior----------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaNoInterior:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;
                            //------------------------------------------------------------------------------------------

                            //M2 Superficie y Superflote tipo------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaM2Superficie:
                                
                                //Se revisa que sea de tipo double
                                if (value != "")
                                {
                                    double M2SuperficieFinal = new double();

                                    bool EsNumM2Super = double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, 
                                                                                out M2SuperficieFinal);
                                    if (EsNumM2Super == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;

                                        if (ValidaNoRepetir(M2SuperficieFinal, Modelo.EncDatosPlano.M2SuperFloteTipo))
                                        {
                                            Modelo.EncDatosPlano.M2SuperFloteTipo.Add(M2SuperficieFinal);
                                        }
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;
                            //---------------------------------------------------------------------------------------------

                            //Unidad Privativa------------------------------------------------------------------------------
                            case Modelo.IndexColumn.USDPColumnaUP:
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    int UPFinal = new int();
                                    bool EsNumUP = int.TryParse(value, out UPFinal);
                                    if (EsNumUP == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                else
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;
                            //---------------------------------------------------------------------------------------------

                            //Dirección (Calle)
                            case Modelo.IndexColumn.USDPColumnaCalle:
                                Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;

                        }

                    }

                }
                #endregion
            }
            else //Multifamiliar-------------------------------------------------------------------------------------------
            {                
                //Reviso que viviendas cumplan con formato y obligatorios
                for (int rows = 0; rows < dtDatosPlano.Rows.Count; rows++)
                {
                    for (int col = 0; col < dtDatosPlano.Rows[rows].Cells.Count; col++)
                    {
                        string value = "";

                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.White;

                        value = (dtDatosPlano.Rows[rows].Cells[col].Value ?? "").ToString();

                        switch (col)
                        {
                            //ID Polílinea Lote
                            case Modelo.IndexColumn.MSDPColumnaIDPlLote:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }

                                break;
                            
                             //Id Polílinea Vivienda
                            case Modelo.IndexColumn.MSDPColumnaIDs:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;
                            
                            //Prototipo
                            case Modelo.IndexColumn.MSDPColumnaPrototipo:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;                                

                            case Modelo.IndexColumn.MSDPColumnaManzana:
                                //Validamos que el dato no este vacío
                                if (value != "")
                                {
                                    int ManzanaFinal = new int();
                                    bool EsNumManzana = int.TryParse(value, out ManzanaFinal);
                                    //Valida que el dato sea de tipo entero
                                    if (EsNumManzana == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    //En dado caso que no sea entero lo muestra en gris
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true; //Envío señal de no avanzar
                                    }
                                }
                                break;

                            case Modelo.IndexColumn.MSDPColumnaLote:
                                //Validamos que el dato no este vacío
                                if (value != "")
                                {
                                    int LoteFinal = new int();
                                    bool EsNumLote = int.TryParse(value, out LoteFinal);
                                    if (EsNumLote == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;

                            case Modelo.IndexColumn.MSDPColumnaNoOficial:
                                //No se realiza validación ya que es alfanumérico
                                Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;
                            case Modelo.IndexColumn.MSDPColumnaPiso:
                                //Validamos que el dato no este vacío
                                if (value != "")
                                {
                                    int Piso = new int();
                                    bool EsNumPiso = int.TryParse(value, out Piso);
                                    if (EsNumPiso == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }                                
                                break;

                            case Modelo.IndexColumn.MSDPColumnaNoInterior:
                                if (value != "")
                                {
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                }
                                //En dado caso que este vacío, lo muestra con color Azul
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;

                            case Modelo.IndexColumn.MSDPColumnaM2Sup:
                                //Se revisa que sea de tipo double
                                if (value != "")
                                {
                                    double M2SuperficieFinal = new double();
                                    bool EsNumM2Super = double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out M2SuperficieFinal);
                                    if (EsNumM2Super == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;

                                        if (Modelo.EncDatosPlano.M2SuperFloteTipo.Count > 0)
                                        {
                                            if (ValidaNoRepetir(M2SuperficieFinal, Modelo.EncDatosPlano.M2SuperFloteTipo) == true)
                                            {
                                                Modelo.EncDatosPlano.M2SuperFloteTipo.Add(M2SuperficieFinal);
                                            }
                                        }
                                        else if (Modelo.EncDatosPlano.M2SuperFloteTipo.Count == 0)
                                        {
                                            Modelo.EncDatosPlano.M2SuperFloteTipo.Add(M2SuperficieFinal);
                                        }
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                else
                                {
                                    dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightBlue;
                                    ErrorVacio = true;
                                }
                                break;

                            case Modelo.IndexColumn.MSDPColumnaUP:
                                if (value != "")
                                {
                                    int UPFinal = new int();
                                    bool EsNumUP = int.TryParse(value, out UPFinal);
                                    if (EsNumUP == true)
                                    {
                                        Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                    }
                                    else
                                    {
                                        dtDatosPlano.Rows[rows].Cells[col].Style.BackColor = System.Drawing.Color.LightGray;
                                        ErrorTipoDato = true;
                                    }
                                }
                                else
                                    Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;

                            case Modelo.IndexColumn.MSDPColumnaCalle:
                                Modelo.EncDatosPlano.VivsSeleccionPlano[rows, col] = value;
                                break;

                        }
                    }
                }
            }          
        }

        public static void OrdenoViviendas(DataGridView dtDatosPlano)
        {
            //Encapsulo DtGview            
            Modelo.EncapsulaBitacora.MDtSeleccionPlano = dtDatosPlano;

            //Inicializo las listas
            Modelo.EncDatosPlano.ListOrdenNoInt = new List<string>();
            Modelo.EncDatosPlano.ListOrdenPiso = new List<string>();
            Modelo.EncDatosPlano.ListOrdenPl = new List<string>();

            int MaxCombo = 0;

            //Separo únicamente los distintos tipos de Ids de Lotes, No. Interior, Pisos.
            foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
            {
                foreach (DataGridViewCell dtcell in dtrow.Cells)
                {
                    switch (dtcell.ColumnIndex)
                    {
                        case Modelo.IndexColumn.MSDPColumnaNoInterior:
                            if (!Modelo.EncDatosPlano.ListOrdenNoInt.Contains(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                Modelo.EncDatosPlano.ListOrdenNoInt.Add(dtrow.Cells[dtcell.ColumnIndex].Value.ToString());

                            Modelo.EncDatosPlano.ListOrdenNoInt.Sort();
                            break;

                        case Modelo.IndexColumn.MSDPColumnaPiso://6
                            if (!Modelo.EncDatosPlano.ListOrdenPiso.Contains(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                Modelo.EncDatosPlano.ListOrdenPiso.Add(dtrow.Cells[dtcell.ColumnIndex].Value.ToString());

                            Modelo.EncDatosPlano.ListOrdenPiso.Sort();
                            break;
                        case Modelo.IndexColumn.MSDPColumnaIDPlLote://0
                            if (!Modelo.EncDatosPlano.ListOrdenPl.Contains(dtrow.Cells[dtcell.ColumnIndex].Value.ToString()))
                                Modelo.EncDatosPlano.ListOrdenPl.Add(dtrow.Cells[dtcell.ColumnIndex].Value.ToString());
                            break;

                        case Modelo.IndexColumn.MSDPColumnaNoOficial:

                            if (((DataGridViewComboBoxCell)dtcell).Items.Count > MaxCombo)
                            {
                                MaxCombo = ((DataGridViewComboBoxCell)dtcell).Items.Count;
                            }

                            break;
                    }

                }
            }            

            Modelo.EncDatosPlano.NoOficialSel = new string[Modelo.EncDatosPlano.ListOrdenPl.Count, MaxCombo];

            foreach(string idPl in Modelo.EncDatosPlano.ListOrdenPl)
            {
                foreach(DataGridViewRow dtrow in dtDatosPlano.Rows)
                {
                    if(dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value.ToString() == idPl)
                    {

                        for(int i = 0; i < ((DataGridViewComboBoxCell)dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items.Count;i++)
                        {
                            string valorActual = (((DataGridViewComboBoxCell)dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items[i]??"").ToString();

                            if (string.IsNullOrWhiteSpace((dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Value ?? "").ToString()))
                                Modelo.EncDatosPlano.NoOficialSel[Modelo.EncDatosPlano.ListOrdenPl.IndexOf(idPl), i] = valorActual;
                            else
                            {
                                if (valorActual == dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial].Value.ToString())
                                {
                                    Modelo.EncDatosPlano.NoOficialSel[Modelo.EncDatosPlano.ListOrdenPl.IndexOf(idPl), i] = valorActual;
                                }
                            }
                        }

                        break;
                        
                    }
                }
            }


            Vista.Multifamiliar.MPntOrdenaViviendas mpOrdenaViv = new Vista.Multifamiliar.MPntOrdenaViviendas();

            mpOrdenaViv.ShowDialog();                    
        }

        public static DataGridView OrdenaDGV (DataGridView dtaOrdenar, bool SiNoInterior)
        {
            //Inicializo Listas----------------------------------------
            Modelo.EncDatosPlano.ListaOrdenValor = new List<int>();

            foreach (DataGridViewRow dtRow in dtaOrdenar.Rows)
            {
                Modelo.EncDatosPlano.ListaOrdenValor.Add(int.Parse(dtRow.Cells[Modelo.IndexColumn.MOVColumnaOrden].Value.ToString()));
            }

            //Lo ordeno de manera ascendente
            Modelo.EncDatosPlano.ListaOrdenValor.Sort();
            //----------------------------------------------------------

            //DGV Final
            DataGridView dtFinal = new DataGridView();
            dtFinal.AllowUserToAddRows = false;

            //Asigno los atributos del DGV Original
            foreach (DataGridViewColumn dtCol in Modelo.EncapsulaBitacora.MDtSeleccionPlano.Columns)
            {
                dtFinal.Columns.Add((DataGridViewColumn)dtCol.Clone());
            }

            //Comienzo a comparar por cada IDPolilínea
            foreach (string IdPolilinea in Modelo.EncDatosPlano.ListOrdenPl)
            {
                //Inicializo DGV
                DataGridView dtAuxiliar = new DataGridView();
                dtAuxiliar.AllowUserToAddRows = false;

                //Asigno los atributos de Columnas del DGV Original                
                foreach (DataGridViewColumn dtCol in Modelo.EncapsulaBitacora.MDtSeleccionPlano.Columns)
                {
                    dtAuxiliar.Columns.Add((DataGridViewColumn)dtCol.Clone());
                }

                //Solamente agrego los renglones que cuenten con el ID Polilínea Lote Actual
                foreach (DataGridViewRow dtrow in Modelo.EncapsulaBitacora.MDtSeleccionPlano.Rows)
                {
                    if (dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value.ToString() == IdPolilinea)
                    {
                        //Inserto renglon
                        int index = dtAuxiliar.Rows.Add();

                        //Asigno valores a renglones insertados
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value.ToString();
                        //((DataGridViewComboBoxCell)dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).DataSource = (().Items;
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaLote].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaUP].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaUP].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value.ToString();

                        //Valores cada Vivienda: Número Interior, Prototipo, Piso
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value.ToString();
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value.ToString();

                        //Le asignó el index 0 si sólo tiene un item de No. Oficial
                        DataGridViewComboBoxCell dtcmb = new DataGridViewComboBoxCell();
                        dtcmb = (DataGridViewComboBoxCell)dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial];
                        dtAuxiliar.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial] = (DataGridViewComboBoxCell)dtcmb.Clone();

                    }
                }

                //Inicio lista de manera ascendente
                foreach (int Orden in Modelo.EncDatosPlano.ListaOrdenValor)
                {
                    string ValorActual = "";

                    //Asigno primer Valor a Insertar (Número Interior o Piso) de acuerdo a DGV
                    foreach (DataGridViewRow dtrowOrden in dtaOrdenar.Rows)
                    {
                        if (int.Parse(dtrowOrden.Cells[Modelo.IndexColumn.MOVColumnaOrden].Value.ToString()) == Orden)
                        {
                            ValorActual = dtrowOrden.Cells[Modelo.IndexColumn.MOVColumnaVAgregado].Value.ToString();
                        }
                    }

                    //Al contar con el valor a tomar en cuenta lo inserto en DTFinal
                    foreach (DataGridViewRow dtrow in dtAuxiliar.Rows)
                    {
                        //Si es Numero Interior
                        if (SiNoInterior == true)
                        {
                            if (dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value.ToString() == ValorActual)
                            {
                                //Inserto renglon
                                int index = dtFinal.Rows.Add();

                                //Asigno valores a renglones insertados
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value.ToString();
                                ((DataGridViewComboBoxCell)dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).DataSource = ((DataGridViewComboBoxCell)Modelo.EncapsulaBitacora.MDtSeleccionPlano.Rows[dtrow.Index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items;
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaLote].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaUP].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaUP].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value.ToString();

                                //Valores cada Vivienda: Número Interior, Prototipo, Piso
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value.ToString();

                                //Le asignó el index 0 si sólo tiene un item de No. Oficial
                                DataGridViewComboBoxCell dtcmb = new DataGridViewComboBoxCell();
                                dtcmb = (DataGridViewComboBoxCell)dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoOficial];
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial] = (DataGridViewComboBoxCell)dtcmb.Clone();

                            }
                        }
                        //Si es Piso
                        else
                        {
                            if (dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value.ToString() == ValorActual)
                            {
                                //Inserto renglon
                                int index = dtFinal.Rows.Add();

                                //Asigno valores a renglones insertados
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDs].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaIDPlLote].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaManzana].Value.ToString();
                                ((DataGridViewComboBoxCell)dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).DataSource = ((DataGridViewComboBoxCell)Modelo.EncapsulaBitacora.MDtSeleccionPlano.Rows[dtrow.Index].Cells[Modelo.IndexColumn.MSDPColumnaNoOficial]).Items;
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaLote].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaLote].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaM2Sup].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaUP].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaUP].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaCalle].Value.ToString();

                                //Valores cada Vivienda: Número Interior, Prototipo, Piso
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaNoInterior].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPrototipo].Value.ToString();
                                dtFinal.Rows[index].Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value = dtrow.Cells[Modelo.IndexColumn.MSDPColumnaPiso].Value.ToString();
                            }
                        }
                    }

                }
               
            }

            return dtFinal;
        }

        internal static bool SiValidaUP(DataGridView dtDatosPlano, int idxColumna)
        {
            //Valida criterio a tomar en cuenta
            bool esVacio = new bool();

                //Reviso si hay algún renglón vacío
                foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
                {
                    if (string.IsNullOrWhiteSpace((dtrow.Cells[idxColumna].Value ?? "").ToString()))
                    {
                        esVacio = true;                        
                    }
                }

                //Si hay alguno vacío, todos deben de ser vacíos
                if(esVacio)
                {
                    //Reviso que todos sean vacíos
                    foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
                    {
                        //Si detecto alguno que no sea vacío, retorno false
                        if (!string.IsNullOrWhiteSpace((dtrow.Cells[idxColumna].Value ?? "").ToString()))
                        {
                            return false;                    
                        }
                    }
                }                            

            return true;
        }        

        internal static bool ValidoPisoNoInt(DataGridView dtDatosPlano)
        {
            bool flag = true;

            foreach (DataGridViewRow dtrow in dtDatosPlano.Rows)
            {
                foreach(DataGridViewCell dtcell in dtrow.Cells)
                {
                    if(dtcell.ColumnIndex == Modelo.IndexColumn.MSDPColumnaNoInterior ||
                        dtcell.ColumnIndex == Modelo.IndexColumn.MSDPColumnaPiso)
                    {
                        if(string.IsNullOrEmpty((dtcell.Value ?? string.Empty).ToString())
                            || string.IsNullOrWhiteSpace((dtcell.Value ?? string.Empty).ToString()))
                        {
                            flag = false;
                            dtcell.Style.BackColor = System.Drawing.Color.LightSkyBlue;
                        }

                    }
                }
            }
            return flag;
        }
    }
}
