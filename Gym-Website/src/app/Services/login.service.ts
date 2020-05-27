import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../Model/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private BASE_URL = "http://localhost:8080";
  private USER_LOGIN_URL = `${this.BASE_URL}/users/login`;
  private USER_SIGNUP_URL = `${this.BASE_URL}/users/add`;
  private USERNAME_EXISTS_URL = `${this.BASE_URL}/users/isUsername`;
  private EMAIL_EXISTS_URL = `${this.BASE_URL}/users/isEmail`;

  constructor(private http : HttpClient) { }

  login(username:string, password:string) : Observable<User> {
    return this.http.get<User>(this.USER_LOGIN_URL+`/${username}/${password}`);
  }

  signUp(user:User) : Observable<any>{
    return this.http.post(this.USER_SIGNUP_URL, user);
  }

  usernameExists(username:string):Observable<boolean>{
    return this.http.get<boolean>(this.USERNAME_EXISTS_URL+`/${username}`);
  }

  emailExists(email:string):Observable<boolean>{
    return this.http.get<boolean>(this.EMAIL_EXISTS_URL+`/${email}`)
  }

}
