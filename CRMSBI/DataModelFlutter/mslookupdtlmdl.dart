 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsLookupDtlMdl {
     String kode;
     String kodeLookup;
     int noUrut;
     String nilaiLookup;
     String nilaiLookup2;
     String nilaiLookup3;
     String nilaiLookup4;
     String displayLookup;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsLookupDtlMdl({
         @required this.kode,
         @required this.kodeLookup,
         @required this.noUrut,
         @required this.nilaiLookup,
         @required this.nilaiLookup2,
         @required this.nilaiLookup3,
         @required this.nilaiLookup4,
         @required this.displayLookup,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsLookupDtlMdl.fromJson(Map<String, dynamic> json) : 

         kode = json["Kode"],
         kodeLookup = json["KodeLookup"],
         noUrut = json["NoUrut"].toInt(),
         nilaiLookup = json["NilaiLookup"],
         nilaiLookup2 = json["NilaiLookup2"],
         nilaiLookup3 = json["NilaiLookup3"],
         nilaiLookup4 = json["NilaiLookup4"],
         displayLookup = json["DisplayLookup"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsLookupDtlMdl.initModel() : 

         kode = null,
         kodeLookup = null,
         noUrut = null,
         nilaiLookup = null,
         nilaiLookup2 = null,
         nilaiLookup3 = null,
         nilaiLookup4 = null,
         displayLookup = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "Kode": kode,
         "KodeLookup": kodeLookup,
         "NoUrut": noUrut,
         "NilaiLookup": nilaiLookup,
         "NilaiLookup2": nilaiLookup2,
         "NilaiLookup3": nilaiLookup3,
         "NilaiLookup4": nilaiLookup4,
         "DisplayLookup": displayLookup,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsLookupDtlMdl", "");
     }
     
     static Future<MsLookupDtlMdl> getData(String kode, String kodeLookup) async {
         try {
             var json = await postRequest("Model/GetMsLookupDtlMdl", {
             "kode": kode, "kodeLookup": kodeLookup
             });
             return MsLookupDtlMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsLookupDtlMdl getModel() {
         try {
             String json = getString("MsLookupDtlMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsLookupDtlMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsLookupDtlMdl oModel) {
         return saveString("MsLookupDtlMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsLookupDtlMdl", jsonEncode(MsLookupDtlMdl.fromJson(oMap)));
      }
 }

