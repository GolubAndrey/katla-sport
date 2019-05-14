import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';
import { User } from '../models/user';

@Injectable()
export class UserService {
  private url = environment.apiUrl;
  constructor(private http: HttpClient) { }

  registerUser(user: User, userRoles : string[]) {
    const body: User = {
      id: user.id,
      userName: user.userName,
      password: user.password,
      firstName: user.firstName,
      lastName: user.lastName,
      roles: userRoles
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.url + '/api/User/Register', body,{headers : reqHeader});
  }

  userAuthentication(userName, password) {
    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });
    return this.http.post(this.url + '/token', data, { headers: reqHeader });
  }

  getUserClaims(){
    return  this.http.get(this.url +'/api/User/GetUserClaims');
  }

  getAllRoles() {
    var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
    return this.http.get(this.url + '/api/GetAllRoles', { headers: reqHeader });
  }

  isAdmin(): boolean {
    var roles = this.getUserRoles();
    return roles.indexOf('Admin') > -1;
  }

  isUser(): boolean {
    var roles = this.getUserRoles();
    return roles.indexOf('User') > -1;
  }

  isManager(): boolean {
    var roles = this.getUserRoles();
    return roles.indexOf('Admin') > -1;
  }

  getUserRoles(): string[] {
    return JSON.parse(localStorage.getItem('userRoles'));
  }
}