import { SavedList } from "./saved-list.model";
enum Role {
  Admin = 'Admin',
  User = 'User'
}

export interface User  {
  name: string ;
  email: string ;
  savedList?: SavedList;
  role?: Role;
  passwordHash: string ;
}
