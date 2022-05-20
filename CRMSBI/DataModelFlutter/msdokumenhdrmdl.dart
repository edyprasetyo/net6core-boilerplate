 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsDokumenHdrMdl {
     String kodeDokumen;
     String keterangan;
     String prefix;
     String sufix;
     int panjangNo;
     String resetBy;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsDokumenHdrMdl({
         @required this.kodeDokumen,
         @required this.keterangan,
         @required this.prefix,
         @required this.sufix,
         @required this.panjangNo,
         @required this.resetBy,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsDokumenHdrMdl.fromJson(Map<String, dynamic> json) : 

         kodeDokumen = json["KodeDokumen"],
         keterangan = json["Keterangan"],
         prefix = json["Prefix"],
         sufix = json["Sufix"],
         panjangNo = json["PanjangNo"].toInt(),
         resetBy = json["ResetBy"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsDokumenHdrMdl.initModel() : 

         kodeDokumen = null,
         keterangan = null,
         prefix = null,
         sufix = null,
         panjangNo = null,
         resetBy = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "KodeDokumen": kodeDokumen,
         "Keterangan": keterangan,
         "Prefix": prefix,
         "Sufix": sufix,
         "PanjangNo": panjangNo,
         "ResetBy": resetBy,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsDokumenHdrMdl", "");
     }
     
     static Future<MsDokumenHdrMdl> getData(String kodeDokumen) async {
         try {
             var json = await postRequest("Model/GetMsDokumenHdrMdl", {
             "kodeDokumen": kodeDokumen
             });
             return MsDokumenHdrMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsDokumenHdrMdl getModel() {
         try {
             String json = getString("MsDokumenHdrMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsDokumenHdrMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsDokumenHdrMdl oModel) {
         return saveString("MsDokumenHdrMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsDokumenHdrMdl", jsonEncode(MsDokumenHdrMdl.fromJson(oMap)));
      }
 }

