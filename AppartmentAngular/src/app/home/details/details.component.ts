import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidenceDto } from '../../.dto/ResidenceDto';
import { ResidenceService } from '../../residence.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(public router: Router, private route: ActivatedRoute, private residenceService: ResidenceService) { }

  typesOfFacilities: string[][] = [["Swimming pool", "pool"], ["Wifi", "network_wifi"], ["Breakfast", "free_breakfast"], ["Kitchen", "kitchen"], ["Television", "live_tv"], ["Nearby beach", "beach_access"], ["Nearby city", "location_city"], ["Nearby subway", "directions_subway"], ["Nearby train station", "train"]];
  usedFacilities: string[][] = [];
  residenceImage = "";
  residenceName = "";
  residence!: ResidenceDto;

  ngOnInit(): void {
    this.getResidenceName().then(paramName => {

      if (paramName == "" || paramName == null)
        return;

      this.residenceService.GetResidenceByName(paramName).then(data => {
        this.residence = data;
        this.updateUsedFacilities();

        this.residenceImage = this.residence.pictures[0].fileName;
        console.dir(data);
      });

    });
  }

  updateUsedFacilities(): void {
    var r = this.residence;
    var facilities = [r.swimmingPool, r.wifi, r.breakfast, r.kitchen, r.television, r.nearbyBeach, r.nearbyCity, r.nearbySubway, r.nearbyTrainStation];

    for (let i = 0; i < facilities.length; i++) {
      if (facilities[i] == true) {
        this.usedFacilities.push(this.typesOfFacilities[i]);
      }
    }

    console.dir(this.usedFacilities);
  }


  getResidenceName() {
    return new Promise<string>((resolve) => {
      this.route.queryParams.subscribe(params => {

          resolve(params['name'].toString());
      });
    })
  }
}
