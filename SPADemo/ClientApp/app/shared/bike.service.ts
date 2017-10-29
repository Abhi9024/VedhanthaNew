import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { IBike } from '../shared/Interface';

@Injectable()
export class BikeService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    getAllBikes(): Observable<IBike[]> {
        return this.http.get(this.baseUrl + 'api/Bike/GetAllBikeInfo')
            .map(result => {
                let bikes = result.json();
                return bikes;
            })
            .catch(this.handleError);
    }

    addBike(bike: IBike): Observable<IBike> {
        return this.http.post(this.baseUrl + 'api/Bike/AddBike', bike)
            .map((res: Response) => {
                const bike = res.json();
                return bike.Bike;
            })
            .catch(this.handleError);
    }


    handleError(error: any) {
        console.log(error);
        return Observable.throw(error);
    }
}
