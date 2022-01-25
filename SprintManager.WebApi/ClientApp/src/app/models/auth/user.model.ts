import {IRole} from "../../registration/registration.component";

export interface IUserDto {
  login: string;
  password: string;
  email: string;
  roleId: number;
}

export class User {
  public login: string;
  public password: string;
  public email: string;
  public roleId: number;

  constructor() {}

  public static fromDto (dto: IUserDto): User {
    let user = new User();
    user.login = dto.login;
    user.password = dto.password;
    user.email = dto.email;
    user.roleId = dto.roleId;

    return user;
  }
}
