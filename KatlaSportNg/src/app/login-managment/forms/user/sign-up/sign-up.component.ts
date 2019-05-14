import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr'
import { User } from '../../../models/user'
import { UserService} from '../../../services/login.service'
import { catchError } from 'rxjs/operators';
import { HttpErrorResponse} from '@angular/common/http'

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  user: User;
  roles: any[]

  constructor(private userService: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    this.userService.getAllRoles().subscribe(
      (data : any)=>{
        console.log(data)
        data.forEach(obj => obj.selected = false);
        this.roles = data;
      }
    );
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.user = {
      id: '',
      userName: '',
      password: '',
      firstName: '',
      lastName: '',
      roles: []
    }
    if (this.roles)
      this.roles.map(x => x.selected = false);
  }

  OnSubmit(form: NgForm) {
    var x = this.roles.filter(x => x.selected).map(y => y.role);
    this.userService.registerUser(form.value, x)
      .subscribe(data =>{
        this.resetForm(form);
        this.toastr.success('User registration successful')},
        (error:HttpErrorResponse) => {
          console.log(error.error)
          this.toastr.error(error.error.message);
        });
  }

  updateSelectedRoles(index) {
    this.roles[index].selected = !this.roles[index].selected;
  }
}
