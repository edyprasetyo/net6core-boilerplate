 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsGroupUserMdl {
     String kodeGroup;
     String namaGroup;
     bool bAdmin;
     bool bUserAdmin;
     bool bUser;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsGroupUserMdl({
         @required this.kodeGroup,
         @required this.namaGroup,
         @required this.bAdmin,
         @required this.bUserAdmin,
         @required this.bUser,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsGroupUserMdl.fromJson(Map<String, dynamic> json) : 

         kodeGroup = json["KodeGroup"],
         namaGroup = json["NamaGroup"],
         bAdmin = json["bAdmin"],
         bUserAdmin = json["bUserAdmin"],
         bUser = json["bUser"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsGroupUserMdl.initModel() : 

         kodeGroup = null,
         namaGroup = null,
         bAdmin = null,
         bUserAdmin = null,
         bUser = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "KodeGroup": kodeGroup,
         "NamaGroup": namaGroup,
         "bAdmin": bAdmin,
         "bUserAdmin": bUserAdmin,
         "bUser": bUser,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsGroupUserMdl", "");
     }
     
     static Future<MsGroupUserMdl> getData(String kodeGroup) async {
         try {
             var json = await postRequest("Model/GetMsGroupUserMdl", {
             "kodeGroup": kodeGroup
             });
             return MsGroupUserMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsGroupUserMdl getModel() {
         try {
             String json = getString("MsGroupUserMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsGroupUserMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsGroupUserMdl oModel) {
         return saveString("MsGroupUserMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsGroupUserMdl", jsonEncode(MsGroupUserMdl.fromJson(oMap)));
      }
 }

