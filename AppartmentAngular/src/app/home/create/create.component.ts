import { AuthService } from './../../auth.service';

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatListOption } from '@angular/material/list/selection-list';
import { Router } from '@angular/router';
import { ResidenceService } from 'src/app/residence.service';
import { ImageDto } from '../../.dto/ImageDto'
import { ResidenceDto } from '../../.dto/ResidenceDto'


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public router: Router, private formBuilder: FormBuilder, private residenceService : ResidenceService) { }

  NameFormControl = new FormControl('', [Validators.required, Validators.email]);

  facilities: string[] = [];
  images: ImageDto[] = [];
  typesOfFacilities: string[][] = [["Swimming pool", "pool"], ["Wifi", "network_wifi"], ["Breakfast", "free_breakfast"], ["Kitchen", "kitchen"], ["Television", "live_tv"], ["Nearby beach", "beach_access"], ["Nearby city", "location_city"], ["Nearby subway", "directions_subway"], ["Nearby train station","train"]];
  listingForm!: FormGroup;

  submitted = false;

  ngOnInit(): void {

    this.listingForm = this.formBuilder.group({
      Name: ["", [Validators.required]],
      Summary: ["", [Validators.required]],
      Bedrooms: ["", [Validators.required]],
      Bathrooms: ["", [Validators.required]],
      Toilets: ["", [Validators.required]],
    });
  }

  checkFacility(facility: string): boolean {
    for (let i = 0; i < this.facilities.length; i++) {
      if (this.facilities[i] == facility)
        return true;
    }

    return false;
  }

  onSubmit(): void {
    this.submitted = true;


    var residence: ResidenceDto = {
      Bathrooms: this.listingForm.controls["Bathrooms"].value as number,
      Bedrooms: this.listingForm.controls["Bedrooms"].value as number,
      Toilets: this.listingForm.controls["Toilets"].value as number,
      Name: this.listingForm.controls["Name"].value,
      Summary: this.listingForm.controls["Summary"].value,

      Breakfast: this.checkFacility("Breakfast"),
      Kitchen: this.checkFacility("Kitchen"),
      SwimmingPool: this.checkFacility("Swimming pool"),
      Television: this.checkFacility("Television"),
      Wifi: this.checkFacility("Wifi"),
      NearbyBeach: this.checkFacility("Nearby beach"),
      NearbyCity: this.checkFacility("Nearby city"),
      NearbySubway: this.checkFacility("Nearby subway"),
      NearbyTrainStation: this.checkFacility("Nearby train station"),

      ResidenceType: 0,
      Pictures: this.images
    }

    console.dir(residence);
    this.residenceService.CreateResidence(residence);
  }

  updateFacilities(facilities: MatListOption[]) {
    this.facilities = [];
    facilities.map(v => this.facilities.push(v.value));
    console.dir(this.facilities);
  }

  removeImage(fileName: string) {
    for (let i = 0; i < this.images.length; i++) {
      if (this.images[i].fileName == fileName)
        this.images.splice(i, 1);
    }
  }

  processImages(ev: any) {

     new Promise<ImageDto[]>((resolve) => {

      let tempImages : ImageDto[] = [];

      if (ev.target.files && ev.target.files.length > 0) {

        for (let i = 0; i < ev.target.files.length; i++) {
          let file = ev.target.files[i];

          let img: ImageDto = { basePath: "", fileName: file.name, order: i }

          var reader = new FileReader();
          reader.readAsDataURL(file);

          reader.onload = (event: any) => {
            img.basePath = event.target.result;
            tempImages.push(img);

            if (tempImages.length == ev.target.files.length)
              resolve(tempImages);
          }
        }
       }

     }).then(tempImages => {
       this.images = tempImages;
     })
  }
}
