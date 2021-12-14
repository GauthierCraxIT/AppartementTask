import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.prod';
import { LoginDto } from './.dto/LoginDto'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }



  Login(_email: string, _password: string) {

    var loginDto: LoginDto = {
      accessToken: "",
      refreshToken: "",
      email: _email,
      password: _password
    }

    return new Promise<LoginDto>((resolve) => {   
      this.http.post(environment.rootApi + "login", loginDto, { observe: 'response' }).subscribe((res) => {

        resolve(res.body as LoginDto);

      }, (error) => {
        resolve(loginDto);
      })
    })
  }
}
