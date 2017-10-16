import { Component, Inject } from '@angular/core';
import { Http} from '@angular/http';

@Component({
    selector: 'bike',
    templateUrl : './bike.component.html'
})
export class BikeComponent {
    public bikes: IBike[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/Bike/GetAllBikeInfo').subscribe(result => { this.bikes = result.json() as IBike[] }, error => console.error(error));
    }
}

interface IBike {
    name: string,
    company: string,
    type: string
}

enum IBikeType {
    Cruser = 1,
    Sports = 2,
    Luxury_Cruser = 3,
    Luxury_Sports = 4,
    Scooter = 5
}