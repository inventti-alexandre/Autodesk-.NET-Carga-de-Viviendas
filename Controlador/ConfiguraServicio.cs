using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace PluginInsViviendas_UNO.Controlador
{
    public class ConfiguraServicio
    {
        public static CustomBinding AsignaCustomBinding()
        {

            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();

            readerQuotas.MaxArrayLength = int.MaxValue;
            readerQuotas.MaxBytesPerRead = int.MaxValue;
            readerQuotas.MaxDepth = int.MaxValue;
            readerQuotas.MaxNameTableCharCount = int.MaxValue;
            readerQuotas.MaxStringContentLength = int.MaxValue;

            //TextEncoding y ReaderQuotas
            TextMessageEncodingBindingElement msgenc = new TextMessageEncodingBindingElement();
            msgenc.MaxReadPoolSize = 64;
            msgenc.MaxWritePoolSize = 16;
            msgenc.MessageVersion = MessageVersion.Soap12;
            msgenc.ReaderQuotas = readerQuotas;
            msgenc.WriteEncoding = Encoding.UTF8;

            //HTTPTRANSPORT
            HttpTransportBindingElement http = new HttpTransportBindingElement();
            http.MaxBufferPoolSize = int.MaxValue;
            http.MaxBufferSize = int.MaxValue;
            http.MaxReceivedMessageSize = int.MaxValue;


            //Binding agregandole transporte y parametros
            CustomBinding cs = new CustomBinding(msgenc, http);
            cs.ReceiveTimeout = TimeSpan.MaxValue;
            cs.SendTimeout = TimeSpan.MaxValue;
            cs.OpenTimeout = TimeSpan.MaxValue;

            return cs;
        }        
    }
}
