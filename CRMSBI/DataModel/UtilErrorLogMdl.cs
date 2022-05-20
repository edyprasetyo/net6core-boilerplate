 using CRMSBI.Helper;
 using NPoco;
 using System;
 
 namespace CRMSBI.Data
 {

     [TableName("UtilErrorLog")]
     [PrimaryKey("ID", AutoIncrement = true)]
     public partial class UtilErrorLogMdl
     {
     
         public double ID { get; set; }
     
         public string Header { get; set; }
     
         public string Url { get; set; }
     
         public string Model { get; set; }
     
         public string ErrorMessage { get; set; }
     
         public string DibuatOleh { get; set; }
     
         public DateTime WaktuDibuat { get; set; }
     
         public string DiubahOleh { get; set; }
     
         public DateTime WaktuDiubah { get; set; }
     
         public static UtilErrorLogMdl GetData(double iD)
         {
             return MdlDtl.GetDataQuery<UtilErrorLogMdl>("SELECT * FROM UtilErrorLog WITH (NOLOCK,NOWAIT) WHERE ID = @0", iD);
         }
         public static UtilErrorLogMdl GetDataTransaction(MdlDto oMdlDto, double iD)
         {
             return oMdlDto.GetData<UtilErrorLogMdl>(iD);
         }
     }
 }

