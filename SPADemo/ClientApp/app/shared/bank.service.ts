import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IProduct } from '../shared/Interface'

@Injectable()
export class BankService {
    headers: Headers;
    options: RequestOptions;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.headers = new Headers({
            'Content-Type': 'application/json',
            'Accept': 'q=0.8;application/json;q=0.9'
        });
        this.options = new RequestOptions({ headers: this.headers });
    }

    getProducts(): Observable<IProduct[]> {
        return this.http.get(this.baseUrl + 'api/BankAcc/GetAll')
            .map(res => {
                let bankProducts = res.json();
                return bankProducts;
            })
            .catch(this.HandleError);
    };

    addOrUpdateProducts(data: IProduct): Observable<IProduct> {
        return this.http.post(this.baseUrl + 'api/BankAcc/Post', data)
            .map(res => {
                return res.json();
            })
            .catch(this.HandleError);
    }

    deleteProduct(name: string): Observable<any> {
        return this.http.delete(this.baseUrl + 'api/BankAcc/Delete?name=' + name, this.options)
            .map((res: Response) => {
                if (res.status==200)
                 return true;
            })
            .catch(this.HandleError);
    }

    HandleError(err: any) {
        console.log(err);
        return err;
    };
}