import { AccountserviceService } from './../../services/accountservice.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  UserResource:any={
    username:[],
    email:[],
    phone:[],
    password:[]
  };
  constructor(private AccountserviceService:AccountserviceService) { }

  ngOnInit() {
  }

  submit(){
    this.AccountserviceService.createuser(this.UserResource).subscribe(x=>console.log(x));
  }

}
