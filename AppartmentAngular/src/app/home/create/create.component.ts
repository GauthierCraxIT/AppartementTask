import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImageDto } from '../../.dto/ImageDto'

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  constructor(public router: Router) { }

  images: ImageDto[] = [];

  ngOnInit(): void {
  }

  processImages(ev: any) {

     new Promise<ImageDto[]>((resolve) => {

      let tempImages : ImageDto[] = [];

      if (ev.target.files && ev.target.files.length > 0) {

        for (let i = 0; i < ev.target.files.length; i++) {
          let file = ev.target.files[i];

          let img: ImageDto = { basePath: "", fileName: file.name }

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
