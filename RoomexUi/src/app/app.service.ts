import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpParams, HttpClient } from '@angular/common/http';
import { CoordinateVM } from './coordinateVM';
import { map, catchError } from 'rxjs/operators';

@Injectable()
export class AppService  {

    constructor(private httpService: HttpClient) {
    }
    
  GetDistance = (model: CoordinateVM): Observable<any> => {
    const self = this;
    const params = new HttpParams()
    .set('latA', model.pointALang)
    .set('lonA', model.pointALong)
    .set('latB', model.pointBLang)
    .set('lonB', model.pointBLong)
    .set('unit', model.unit);
    

    return this.httpService.get("http://localhost:53204/api/sphere/" + model.strategy + "/GetDistance", {params: params})
    .pipe(
        map((e: Response) => {
          return e;
        }),
        catchError((e: Response) => throwError(e))
      );
  }
}
