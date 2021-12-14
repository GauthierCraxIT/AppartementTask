import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.prod';
import { LoginDto } from './.dto/LoginDto';
import { RegisterDto } from './.dto/RegisterDto'

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


  Register(_firstName: string, _lastName: string, _email: string, _password: string) {

    var registerDto: RegisterDto = {
      accessToken: "",
      refreshToken: "",
      firstName: _firstName,
      lastName: _lastName,
      email: _email,
      password: _password,
      repeatPassword: "",
      userName: "UNSET"
    }


    return new Promise<RegisterDto>((resolve) => {
      this.http.post(environment.rootApi + "register", registerDto, { observe: 'response' }).subscribe((res) => {

        resolve(res.body as RegisterDto);

      }, (error) => {
        resolve(registerDto); //return empty object 
      })
    })

  }
}
