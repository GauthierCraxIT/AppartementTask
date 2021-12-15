import { environment } from './../environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {ResidenceDto} from './.dto/ResidenceDto'

@Injectable({
  providedIn: 'root'
})
export class ResidenceService {

  constructor(private http: HttpClient) { }


  CreateFacility(residenceDto : ResidenceDto) {
    return new Promise<ResidenceDto>((resolve) => {
      this.http.post(environment.rootApi + "residence", residenceDto, {observe: 'response'}).subscribe(response => {
        resolve(response.body as ResidenceDto);
      });
    });
  }
}