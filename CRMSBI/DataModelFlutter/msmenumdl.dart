 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsMenuMdl {
     String kodeMenu;
     String judulMenu;
     String parentMenu;
     int urutanMenu;
     bool bTampil;
     bool bParent;
     bool bPemisah;
     String namaController;
     String namaAction;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsMenuMdl({
         @required this.kodeMenu,
         @required this.judulMenu,
         @required this.parentMenu,
         @required this.urutanMenu,
         @required this.bTampil,
         @required this.bParent,
         @required this.bPemisah,
         @required this.namaController,
         @required this.namaAction,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsMenuMdl.fromJson(Map<String, dynamic> json) : 

         kodeMenu = json["KodeMenu"],
         judulMenu = json["JudulMenu"],
         parentMenu = json["ParentMenu"],
         urutanMenu = json["UrutanMenu"].toInt(),
         bTampil = json["bTampil"],
         bParent = json["bParent"],
         bPemisah = json["bPemisah"],
         namaController = json["NamaController"],
         namaAction = json["NamaAction"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsMenuMdl.initModel() : 

         kodeMenu = null,
         judulMenu = null,
         parentMenu = null,
         urutanMenu = null,
         bTampil = null,
         bParent = null,
         bPemisah = null,
         namaController = null,
         namaAction = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "KodeMenu": kodeMenu,
         "JudulMenu": judulMenu,
         "ParentMenu": parentMenu,
         "UrutanMenu": urutanMenu,
         "bTampil": bTampil,
         "bParent": bParent,
         "bPemisah": bPemisah,
         "NamaController": namaController,
         "NamaAction": namaAction,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsMenuMdl", "");
     }
     
     static Future<MsMenuMdl> getData(String kodeMenu) async {
         try {
             var json = await postRequest("Model/GetMsMenuMdl", {
             "kodeMenu": kodeMenu
             });
             return MsMenuMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsMenuMdl getModel() {
         try {
             String json = getString("MsMenuMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsMenuMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsMenuMdl oModel) {
         return saveString("MsMenuMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsMenuMdl", jsonEncode(MsMenuMdl.fromJson(oMap)));
      }
 }

