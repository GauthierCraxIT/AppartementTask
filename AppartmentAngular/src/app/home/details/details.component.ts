import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResidenceService } from '../../residence.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor(public router: Router, private route: ActivatedRoute, private residenceService: ResidenceService) { }

  residenceName = "";

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.residenceName = params['name'];

      if (this.residenceName != "" || this.residenceName != null) {
        this.residenceService.GetResidenceByName(this.residenceName).then(data => {
          console.dir(data);
        });
      }
    });

    
  }



}
