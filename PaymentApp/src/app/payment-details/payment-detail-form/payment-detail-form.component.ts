import { Component } from '@angular/core';
import { PaymentDetailService } from '../../shared/payment-detail.service'; 
import { NgForm } from '@angular/forms';
import { PaymentDetail } from '../../shared/payment-detail.model'; 
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-detail-form',
  templateUrl: './payment-detail-form.component.html',
  styleUrl: './payment-detail-form.component.css'
})
export class PaymentDetailFormComponent {

  constructor(public service: PaymentDetailService , private toastr:ToastrService) {

  }



  onSubmit(form: NgForm) {
    const checkbox = document.getElementById(
      'flexSwitchCheckDefault',
    ) as HTMLInputElement | null;

    if (checkbox?.checked) {
      this.service.formSubmitted = true
      if(form.valid){
        if(this.service.formData.id == "")
        {
          this.insertRecord(form)
        }
        else
        {
          this.updateRecord(form)
        }  
      }
    } else {
      this.toastr.error('Please Agree to the T&C','T&C consent required');
    }

    // this.service.formSubmitted = true
    // if(form.valid){
    //   if(this.service.formData.id == "")
    //   {
    //     this.insertRecord(form)
    //   }
    //   else
    //   {
    //     this.updateRecord(form)
    //   }  
    // }
  }


  insertRecord(form: NgForm){
    this.service.postPaymentDetail().subscribe({
      next: res => {
        console.log(res);
        this.service.list = res as PaymentDetail[]
        this.service.resetForm(form)
        this.toastr.success('Inserted Succesffuly','Payment Details Registered')
      },
      error: err => { console.log(err) }
    })
  }


  updateRecord(form: NgForm){
    this.service.putPaymentDetail().subscribe({
      next: res => {
        console.log(res);
        this.service.list = res as PaymentDetail[]
        this.service.resetForm(form)
        this.toastr.info('Updated Succesffuly','Payment Details Updated Successfully')
      },
      error: err => { console.log(err) }
    })
  }


}


