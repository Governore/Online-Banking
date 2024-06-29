import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-payment-transfer',
  templateUrl: './payment-transfer.component.html',
  styleUrl: './payment-transfer.component.css'
})
export class PaymentTransferComponent {

    account = [
      {"number": 681471112710},
      {"number": 419475030294},
      {"number": 746154802813}
    ]

    userForm: FormGroup;

    userObj: any = {
      accountnumber: '',
      comment: '',
      email: '',
      bankaccount: '',
      amount: '',
      isAgree: false
    }

    constructor(){
      this.userForm = new FormGroup({
        accountnumber: new FormControl("",[Validators.required]),
        comment: new FormControl("",[Validators.required]),
        email: new FormControl("",[Validators.required,Validators.email]),
        bankaccount: new FormControl("",Validators.required),
        amount: new FormControl("",Validators.required)
      });
    }

    onSubmit(): void {
      if (this.userForm.valid) {
        // handle form submission
        console.log(this.userForm.value);
      }
    }
}
