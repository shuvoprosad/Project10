import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class AccountserviceService {

  constructor(private http: Http) { }

  createuser(UserResource) {
    return this.http.post('/account/new', UserResource)
      .map(res => res.json);
  }

  signin(SigninResource){
    return this.http.post('/account/signin', SigninResource)
      .map(res => res.json);
  }

  setroom(RoomResource){
    return this.http.post('/room/set',RoomResource)
      .map(res => res.json);
  }
}
