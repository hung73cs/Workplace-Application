import { HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from './auth/_models/login.model';
import { Observable } from 'rxjs';
import { ResponseModel } from './auth/_models/response.model';
import { RegisterModel } from './auth/_models/register.model';
import { ChangePasswordModel } from './auth/_models/change-password.model';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements HttpInterceptor{
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = req.clone({
      setHeaders: {
        'Content-Type' : 'application/json; charset=utf-8',
        'Accept'       : 'application/json',
        'Authorization': `Bearer `+ (localStorage.getItem('token')).replace(/\"/g, ""),
      },
    });
    return next.handle(req);
  }
  

  authURl = 'https://localhost:44324';

  constructor(private http: HttpClient) {

  }

  login(model: LoginModel): Observable<ResponseModel> {
    const url = `${this.authURl}/login/login`;
    var response = this.http.post<ResponseModel>(url, model);
    console.log((localStorage.getItem('token')).replace(/\"/g, ""));
    return response;
  }

  register(model: RegisterModel): Observable<ResponseModel> {
    const url = `${this.authURl}/user/createuser`;
    var response = this.http.post<ResponseModel>(url, model);
    return response;
  }

  changePassword(model: ChangePasswordModel): Observable<ResponseModel> {
    const url = `${this.authURl}/user/changepassword`;
    var response = this.http.post<ResponseModel>(url, model);
    return response;
  }
}
