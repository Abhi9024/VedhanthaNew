import { Component, OnInit } from '@angular/core';
import { BankService } from '../../shared/bank.service';
import { IProduct } from '../../shared/Interface';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UpperCasePipe } from '@angular/common';

@Component({
    selector: 'bank-acc',
    templateUrl: './bank.component.html',
    providers: [BankService]
})
export class BankAccessorries {
    bankProducts: IProduct[];
    bankAcc: IProduct ={
        productName: '',
        productDescription: '',
        price: ''
    };
    bankAccForm: FormGroup;
    public isAddBankProductEnabled: boolean = false;
    public isDeleteBankProductEnabled: boolean = false;
    public image = require('../bank/Images/Desert.jpg');

    constructor(private bankService: BankService, private formBuilder: FormBuilder, private uppercase: UpperCasePipe) { }

    ngOnInit(): void {
        this.getBankProducts();
        this.buildForm();
    }

    getBankProducts() {
        this.bankService.getProducts()
            .subscribe(res => {
                
                this.bankProducts = res;
            },
            (err) => console.log(err));
    }

    

    buildForm() {
        this.bankAccForm = this.formBuilder.group({
            productName: [this.bankAcc.productName, Validators.required],
            productDescription: [this.bankAcc.productDescription, Validators.required],
            price: [this.bankAcc.price, Validators.required]
        });
    }

    submit({ value, valid }: { value: IProduct, valid: boolean }) {
        this.bankService.addOrUpdateProducts(value)
            .subscribe(res => {
                this.getBankProducts();
            },
            (err) => console.log(err));
    }

    delete(name: string) {
        this.bankService.deleteProduct(name)
            .subscribe(res => {
                this.getBankProducts();
            },(err) => console.log(err));
    }

    addbankproduct(): void {
        this.isAddBankProductEnabled = this.isAddBankProductEnabled ? false : true;
    };

    deletebankproduct(): void {
        this.isDeleteBankProductEnabled = this.isDeleteBankProductEnabled ? false : true;
    };
}