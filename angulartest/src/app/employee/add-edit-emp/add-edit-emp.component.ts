import { Component, OnInit,Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css']
})
export class AddEditEmpComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() emp:any;
  EmployersId:boolean;
  EmployersName:string;
  EmployersSurname:string;
  EmployersYearofBirth:string;
  EmployersPhone:string


  ngOnInit(): void {
  }


  addEmployee(){
    var val = {
                EmployersName:this.EmployersName,
                EmployersSurname: this.EmployersSurname,
                EmployersYearofBirth: this.EmployersYearofBirth,
                EmployersPhone: this.EmployersPhone,
           };

    this.service.addEmployee(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateEmployee(){
    var val = {
      EmployersPhone: this.EmployersPhone,
      EmployersId: this.EmployersId
  };

    this.service.updateEmployee(val).subscribe(res=>{
    alert(res.toString());
    });
  }


  
  }



