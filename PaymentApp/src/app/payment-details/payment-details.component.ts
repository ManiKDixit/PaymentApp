import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from '../shared/payment-detail.service'; 
import { PaymentDetail } from '../shared/payment-detail.model'; 
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrl: './payment-details.component.css'
})
export class PaymentDetailsComponent {

  constructor(public service: PaymentDetailService , private toastr:ToastrService) {

  }

  ngOnInit(): void {
    this.service.refreshList()
  }

  populateForm(selectedRecord:PaymentDetail) {
    this.service.formData = Object.assign({},selectedRecord);
  }


  onDelete(id:string){
    if(confirm("Are you sure to delete this record ?"))
    this.service.deletePaymentDetail(id).subscribe({
      next: res => {
        console.log(res);
        this.service.list = res as PaymentDetail[]
        
        this.toastr.error('Deleted Succesffuly','Payment Details Updated Successfully')
      },
      error: err => { console.log(err) }
    })
  }

}
