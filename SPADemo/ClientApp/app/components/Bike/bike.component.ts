import { Component, Inject, OnInit } from '@angular/core';
import { BikeService } from '../../shared/bike.service';
import { IBike } from '../../shared/Interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'bike',
    templateUrl: './bike.component.html',
    providers: [BikeService]
})
export class BikeComponent {
    public bikes: IBike[] = [];
    bikeForm: FormGroup;
    bike: IBike = {
        name: '',
        company: '',
        type: ''
    };
    public isAddBikeFormHidden: boolean = false;

    constructor(private bikeService: BikeService, private formBuilder: FormBuilder) { }

    ngOnInit(): void {
        this.getAllBikes();
        this.buildForm();
    }

    getAllBikes() {
        this.bikeService.getAllBikes()
            .subscribe((bikeList: IBike[]) => {
                this.bikes = bikeList;
            },
            (err: any) => console.log(err),
            () => console.log('getAllBikes() retrieved all bikes'));
    };

    buildForm() {
        this.bikeForm = this.formBuilder.group({
            name: [this.bike.name, Validators.required],
            company: [this.bike.company, Validators.required],
            type: [this.bike.type, Validators.required]
        });
    };

    submit({ value, valid }: { value: IBike, valid: boolean }) {
        this.bikeService.addBike(value)
            .subscribe((bike: IBike) => {
                this.getAllBikes();
            },
            (err) => console.log(err));
            
    };

    addbike(): void {
        this.isAddBikeFormHidden =  this.isAddBikeFormHidden ? false : true;
    };
}