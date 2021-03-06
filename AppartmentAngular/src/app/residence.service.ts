import { environment } from './../environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {ResidenceDto} from './.dto/ResidenceDto'

@Injectable({
  providedIn: 'root'
})
export class ResidenceService {

  constructor(private http: HttpClient) { }


  CreateResidence(residenceDto : ResidenceDto) {
    return new Promise<ResidenceDto>((resolve) => {
      this.http.post(environment.rootApi + "residence", residenceDto, {observe: 'response'}).subscribe(response => {
        resolve(response.body as ResidenceDto);
      });
    });
  }

  UpdateResidence(residenceDto: ResidenceDto) {
    return new Promise<ResidenceDto>((resolve) => {
      this.http.put(environment.rootApi + "residence", residenceDto, { observe: 'response' }).subscribe(response => {
        resolve(response.body as ResidenceDto);
      });
    });
  }

  GetResidenceByName(name: string) {
    return new Promise<ResidenceDto>((resolve) => {
      this.http.get<ResidenceDto>(environment.rootApi + "residence/byname?name=" + name).subscribe(response => {

        resolve(response as ResidenceDto);
      })
    })
  }

  GetRecidences() {
    return new Promise<ResidenceDto[]>((resolve) => {
      this.http.get<ResidenceDto[]>(environment.rootApi + "residence").subscribe(response => {

        resolve(response as ResidenceDto[]);
      })
    })
  }
}
