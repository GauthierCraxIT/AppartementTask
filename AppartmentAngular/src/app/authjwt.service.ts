import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { UpdateTokenDto } from './.dto/UpdateTokenDto'

@Injectable({
  providedIn: 'root'
})
export class AuthjwtService {

  constructor(private http: HttpClient, public router: Router) { }


  UpdateTokens() {
    var updateTokenDto: UpdateTokenDto = {
      RefreshToken: localStorage.getItem("refreshtoken")!,
      AccessToken: localStorage.getItem("accesstoken")!
    };

    this.http.post("updatetokens", updateTokenDto, { observe: 'response' }).subscribe(response => {

      var res = response.body as UpdateTokenDto;
      localStorage.setItem("refreshtoken", res.RefreshToken);
      localStorage.setItem("accesstoken", res.AccessToken);

    }, (error) => {

      localStorage.setItem("refreshtoken", "");
      localStorage.setItem("accesstoken", "");
      this.router.navigate(["/login"]);
    });
  }
}
