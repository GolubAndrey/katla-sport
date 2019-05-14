import { Component, OnInit } from '@angular/core';
import { User } from 'app/login-managment/models/user';
import { UserService} from '../login-managment/services/login.service'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  //userClaims = new User("","","","","");
  userClaims: any;
  userString = ""

  constructor(
    private userService: UserService,
    private router: Router) {}

  ngOnInit() {
    this.userService.getUserClaims().subscribe(c => {
      this.userClaims = c;
      this.userString = this.userToString();
      console.log(this.userString)});
  }

  userToString(){
    return "<strong>UserName:</strong> " + this.userClaims.userName.toString() + "<br><strong>First name:</strong> " + this.userClaims.firstName.toString() + 
      "<br><strong>Last name:</strong> " + this.userClaims.lastName.toString()+ "<br><strong>Roles:</strong> " + this.userService.getUserRoles().join(", ");
  }

  logOut(){
    localStorage.removeItem("userToken");
    this.router.navigate([`/login`]);
  }

}
