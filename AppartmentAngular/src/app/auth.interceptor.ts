import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../app/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // Get the auth token from the service.

    console.log("testingggg");

    var authToken = "";
    if (localStorage.getItem("accesstoken") != null) 
        authToken = localStorage.getItem("accesstoken")!;

    // Clone the request and replace the original headers with
    // cloned headers, updated with the authorization.
    const authReq = req.clone({
      headers: req.headers.set('Authorization', "bearer " + authToken)
    });


    return next.handle(authReq);
  }
}