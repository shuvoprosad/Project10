import { AccountserviceService } from './../../services/accountservice.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from "@angular/router";
import { Router} from "@angular/router";
import { ToastyService } from "ng2-toasty";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    SigninResource:any={
    email:[],
    password:[]
  };
  constructor(
    private AccountserviceService:AccountserviceService,
    private route:ActivatedRoute,
    private router:Router,
    private toastyService:ToastyService) { }

  ngOnInit() {
  }

    submit(){
    this.AccountserviceService.signin(this.SigninResource).subscribe(
      x=>
      {
        if(x)
        {
          localStorage.setItem('currentUser', JSON.stringify(x));
          this.router.navigate(['room/new']);
        }
      },
      err=>
      {
        if(err.status==400)
        {
            this.toastyService.error(
              {
                title:'Error',
                msg:'Unexpected error check your email and password',
                theme:'bootstrap',
                showClose:true,
                timeout:10000
            });
        }
      }

    );
  }

}
