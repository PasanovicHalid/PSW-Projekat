export class LoginUserDto {
    username: string = '';
    password: string = '';
    flag: string = 'PZL';

    public constructor(obj?: any) {
        if (obj) {
            this.username = obj.username;
            this.password = obj.password;
            this.flag = 'PZL';
        }
    }
  }
