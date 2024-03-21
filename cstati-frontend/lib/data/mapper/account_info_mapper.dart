import 'package:event_flow/data/api/api_models/api_account_info.dart';
import 'package:event_flow/domain/model/account_info.dart';

class AccountInfoMapper {
  static AccountInfo fromApi(ApiAccountInfo userInfo) {
    return AccountInfo(
      login: userInfo.login,
      fullName: userInfo.fullName,
      accesses: userInfo.accesses,
    );
  }
}
