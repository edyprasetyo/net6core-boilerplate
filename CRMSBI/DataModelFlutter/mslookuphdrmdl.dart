 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsLookupHdrMdl {
     String kode;
     String keterangan;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsLookupHdrMdl({
         @required this.kode,
         @required this.keterangan,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsLookupHdrMdl.fromJson(Map<String, dynamic> json) : 

         kode = json["Kode"],
         keterangan = json["Keterangan"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsLookupHdrMdl.initModel() : 

         kode = null,
         keterangan = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "Kode": kode,
         "Keterangan": keterangan,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsLookupHdrMdl", "");
     }
     
     static Future<MsLookupHdrMdl> getData(String kode) async {
         try {
             var json = await postRequest("Model/GetMsLookupHdrMdl", {
             "kode": kode
             });
             return MsLookupHdrMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsLookupHdrMdl getModel() {
         try {
             String json = getString("MsLookupHdrMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsLookupHdrMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsLookupHdrMdl oModel) {
         return saveString("MsLookupHdrMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsLookupHdrMdl", jsonEncode(MsLookupHdrMdl.fromJson(oMap)));
      }
 }

