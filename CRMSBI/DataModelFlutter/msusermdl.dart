 import "dart:convert";
 import "package:flutter/foundation.dart";
 import "../helper/tools.dart";

     
 class MsUserMdl {
     String noUser;
     String userID;
     String nama;
     String email;
     String kodeGroup;
     String password;
     bool bAktif;
     String dibuatOleh;
     DateTime waktuDibuat;
     String diubahOleh;
     DateTime waktuDiubah;
     
     MsUserMdl({
         @required this.noUser,
         @required this.userID,
         @required this.nama,
         @required this.email,
         @required this.kodeGroup,
         @required this.password,
         @required this.bAktif,
         @required this.dibuatOleh,
         @required this.waktuDibuat,
         @required this.diubahOleh,
         @required this.waktuDiubah,
     });
     
     MsUserMdl.fromJson(Map<String, dynamic> json) : 

         noUser = json["NoUser"],
         userID = json["UserID"],
         nama = json["Nama"],
         email = json["Email"],
         kodeGroup = json["KodeGroup"],
         password = json["Password"],
         bAktif = json["bAktif"],
         dibuatOleh = json["DibuatOleh"],
         waktuDibuat = deserializeDatetimeModel(json["WaktuDibuat"]),
         diubahOleh = json["DiubahOleh"],
         waktuDiubah = deserializeDatetimeModel(json["WaktuDiubah"]);     
     MsUserMdl.initModel() : 

         noUser = null,
         userID = null,
         nama = null,
         email = null,
         kodeGroup = null,
         password = null,
         bAktif = null,
         dibuatOleh = null,
         waktuDibuat = null,
         diubahOleh = null,
         waktuDiubah = null;     
     Map<String, dynamic> toJson() => { 
     

         "NoUser": noUser,
         "UserID": userID,
         "Nama": nama,
         "Email": email,
         "KodeGroup": kodeGroup,
         "Password": password,
         "bAktif": bAktif,
         "DibuatOleh": dibuatOleh,
         "WaktuDibuat": serializeDatetime(waktuDibuat),
         "DiubahOleh": diubahOleh,
         "WaktuDiubah": serializeDatetime(waktuDiubah)     };     
     static void deleteModel() {
         return saveString("MsUserMdl", "");
     }
     
     static Future<MsUserMdl> getData(String noUser) async {
         try {
             var json = await postRequest("Model/GetMsUserMdl", {
             "noUser": noUser
             });
             return MsUserMdl.fromJson(json);
          } catch (e) {
             return null;
          }
      }
      
      static MsUserMdl getModel() {
         try {
             String json = getString("MsUserMdl");
             Map<String, dynamic> oMap = jsonDecode(json);
             return MsUserMdl.fromJson(oMap);
         } catch (e) {
             return null;
         }
      }
      
      static void saveModel(MsUserMdl oModel) {
         return saveString("MsUserMdl", jsonEncode(oModel));
      }
      
      static void saveModelJson(Map<String, dynamic> oMap) {
         return saveString("MsUserMdl", jsonEncode(MsUserMdl.fromJson(oMap)));
      }
 }

