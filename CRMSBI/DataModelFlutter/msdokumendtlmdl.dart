 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsDokumenDtlMdl {
     String kodeDokumen;
     String periode;
     int noUrut;
     
     MsDokumenDtlMdl({
         @required this.kodeDokumen,
         @required this.periode,
         @required this.noUrut,
     });
     
     MsDokumenDtlMdl.fromJson(Map<String, dynamic> json) : 

         kodeDokumen = json["KodeDokumen"],
         periode = json["Periode"],
         noUrut = json["NoUrut"].toInt();     
     MsDokumenDtlMdl.initModel() : 

         kodeDokumen = null,
         periode = null,
         noUrut = null;     
     Map<String, dynamic> toJson() => { 
     

         "KodeDokumen": kodeDokumen,
         "Periode": periode,
         "NoUrut": noUrut     };     
     static void deleteModel() {
         return saveString("MsDokumenDtlMdl", "");
     }
     
     static Future<MsDokumenDtlMdl> getData(String kodeDokumen, String periode) async {
         try {
             var json = await postRequest("Model/GetMsDokumenDtlMdl", {
             "kodeDokumen": kodeDokumen, "periode": periode
             });
             return MsDokumenDtlMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsDokumenDtlMdl getModel() {
         try {
             String json = getString("MsDokumenDtlMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsDokumenDtlMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsDokumenDtlMdl oModel) {
         return saveString("MsDokumenDtlMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsDokumenDtlMdl", jsonEncode(MsDokumenDtlMdl.fromJson(oMap)));
      }
 }

