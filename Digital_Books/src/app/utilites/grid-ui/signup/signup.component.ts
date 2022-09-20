import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserData } from 'src/app/model/userdata';
import { LoginServiceService } from 'src/app/services/login-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  UserData: UserData =new UserData();

  constructor(private _service:LoginServiceService,private _router:Router) { }

  ngOnInit(): void {
  }
  registeruser()
  {
    debugger;
    this._service.registerUser(this.UserData).subscribe(res=>{
      localStorage.setItem('token',res.token);
      this._router.navigate(['home']);
    },res=>console.log(res));  
  }
}
