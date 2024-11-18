import { User } from "./User";

export class LoginResponse {
    token!: string;
    role!: string;
    user!: User;
}
