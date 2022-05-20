 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class UtilErrorLogMdl {
     double iD;
     String header;
     String url;
     String model;
     String errorMessage;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     UtilErrorLogMdl({
         @required this.iD,
         @required this.header,
         @required this.url,
         @required this.model,
         @required this.errorMessage,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     UtilErrorLogMdl.fromJson(Map<String, dynamic> json) : 

         iD = json["ID"].toDouble(),
         header = json["Header"],
         url = json["Url"],
         model = json["Model"],
         errorMessage = json["ErrorMessage"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     UtilErrorLogMdl.initModel() : 

         iD = null,
         header = null,
         url = null,
         model = null,
         errorMessage = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "ID": iD,
         "Header": header,
         "Url": url,
         "Model": model,
         "ErrorMessage": errorMessage,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("UtilErrorLogMdl", "");
     }
     
     static Future<UtilErrorLogMdl> getData(double iD) async {
         try {
             var json = await postRequest("Model/GetUtilErrorLogMdl", {
             "iD": iD
             });
             return UtilErrorLogMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static UtilErrorLogMdl getModel() {
         try {
             String json = getString("UtilErrorLogMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return UtilErrorLogMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(UtilErrorLogMdl oModel) {
         return saveString("UtilErrorLogMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("UtilErrorLogMdl", jsonEncode(UtilErrorLogMdl.fromJson(oMap)));
      }
 }

