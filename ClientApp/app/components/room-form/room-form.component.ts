import { ToastyService } from 'ng2-toasty';
import { AccountserviceService } from './../../services/accountservice.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-room-form',
  templateUrl: './room-form.component.html',
  styleUrls: ['./room-form.component.css']
})
export class RoomFormComponent implements OnInit {

  RoomResource:any={
    roomname:[],
    reason:[],
    date:[],
    time:[]
  };

  constructor(private AccountserviceService:AccountserviceService,
    private toastyService:ToastyService) { }

  ngOnInit() {
  }

  submit() {
    this.AccountserviceService.setroom(this.RoomResource).subscribe(
      x=>
      {
        if(x)
        {
          this.toastyService.success(
            {
              title:'Success',
              msg:'Your request is sent to the admin',
              theme:'bootstrap',
              showClose:true,
              timeout:10000
          });
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
