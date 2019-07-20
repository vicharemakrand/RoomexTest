import { Component, OnInit } from '@angular/core';
import { CoordinateVM } from './coordinateVM';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {

  constructor(private appService: AppService) {
  }
  
  title = 'Roomex Test UI developed by Makarand Vichare';
  model : CoordinateVM;
  result: number;
  message:string;
  processing:boolean;

  ngOnInit(): void {
    this.processing = true;
    this.message ='';

    this.model = {
      pointALang: '53.297975',
      pointALong:'-6.372663',
      pointBLang:'41.385101',
      pointBLong:'-81.440440',
      unit:'km',
      strategy:'Strategy1'
    }
 }


  public onSubmit() : void {
    event.preventDefault();
    this.processing = true;
     this.appService.GetDistance(this.model).subscribe(o=>{
      this.message ='';
      if(!o.isSucceed){
        this.message = o.message;
      }
      this.result = o.result;
      this.processing = false;
     })
  
  }
  
}
