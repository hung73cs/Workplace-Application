import { Component, OnInit } from '@angular/core';
import { SmartTableData } from '../../../@core/data/smart-table';

@Component({
  selector: 'ngx-getuser',
  templateUrl: './getuser.component.html',
  styleUrls: ['./getuser.component.scss']
})
export class GetuserComponent implements OnInit {


  constructor(private service: SmartTableData) {
    const data = this.service.getData();
  }
  ngOnInit(): void {
  }

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    // columns: {
    //   id: {
    //     title: 'ID',
    //     type: 'number',
    //   },
    //   UserName: {
    //     title: 'User Name',
    //     type: 'string',
    //   },
    //   DisplayName: {
    //     title: 'Display Name',
    //     type: 'string',
    //   },
    //   PhoneNumber: {
    //     title: 'PhoneNumber',
    //     type: 'string',
    //   },
    //   Birthday: {
    //     title: 'Birthday',
    //     type: 'Date',
    //   },
    //   DepartmentId: {
    //     title: 'DepartmentId',
    //     type: 'number',
    //   },
    // },
    
  };
  source: string[]=[];
  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
}
