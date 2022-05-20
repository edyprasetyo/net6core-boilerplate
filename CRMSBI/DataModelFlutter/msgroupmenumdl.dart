 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsGroupMenuMdl {
     String kodeGroup;
     String kodeMenu;
     bool bView;
     bool bNew;
     bool bEdit;
     bool bDelete;
     bool bPrint;
     bool bProcess;
     bool bGenerate;
     bool bValidate;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsGroupMenuMdl({
         @required this.kodeGroup,
         @required this.kodeMenu,
         @required this.bView,
         @required this.bNew,
         @required this.bEdit,
         @required this.bDelete,
         @required this.bPrint,
         @required this.bProcess,
         @required this.bGenerate,
         @required this.bValidate,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsGroupMenuMdl.fromJson(Map<String, dynamic> json) : 

         kodeGroup = json["KodeGroup"],
         kodeMenu = json["KodeMenu"],
         bView = json["bView"],
         bNew = json["bNew"],
         bEdit = json["bEdit"],
         bDelete = json["bDelete"],
         bPrint = json["bPrint"],
         bProcess = json["bProcess"],
         bGenerate = json["bGenerate"],
         bValidate = json["bValidate"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsGroupMenuMdl.initModel() : 

         kodeGroup = null,
         kodeMenu = null,
         bView = null,
         bNew = null,
         bEdit = null,
         bDelete = null,
         bPrint = null,
         bProcess = null,
         bGenerate = null,
         bValidate = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "KodeGroup": kodeGroup,
         "KodeMenu": kodeMenu,
         "bView": bView,
         "bNew": bNew,
         "bEdit": bEdit,
         "bDelete": bDelete,
         "bPrint": bPrint,
         "bProcess": bProcess,
         "bGenerate": bGenerate,
         "bValidate": bValidate,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsGroupMenuMdl", "");
     }
     
     static Future<MsGroupMenuMdl> getData(String kodeGroup, String kodeMenu) async {
         try {
             var json = await postRequest("Model/GetMsGroupMenuMdl", {
             "kodeGroup": kodeGroup, "kodeMenu": kodeMenu
             });
             return MsGroupMenuMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsGroupMenuMdl getModel() {
         try {
             String json = getString("MsGroupMenuMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsGroupMenuMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsGroupMenuMdl oModel) {
         return saveString("MsGroupMenuMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsGroupMenuMdl", jsonEncode(MsGroupMenuMdl.fromJson(oMap)));
      }
 }

