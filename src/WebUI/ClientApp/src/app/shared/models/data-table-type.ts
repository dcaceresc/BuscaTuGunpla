
export interface Column<T> {
  title:string;
  dataProperty: keyof T;
  // Add here any additional action or information
  // about a generic table column, like whether it is
  // sortable or not.
  sortable?: boolean;
  filterable?:boolean;
}
