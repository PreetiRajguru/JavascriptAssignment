import { Dialog, DialogContent, DialogTitle } from "@mui/material"
import { Customer } from "./Customers";

const Modal = ({customer, onClose}: {customer: Customer, onClose: () => void}) => {
    return (

        <Dialog open onClose={onClose}>
            <DialogTitle>Customer data</DialogTitle>
            <DialogContent>
                Name : {customer.firstName}&nbsp;
                {customer.lastName}<br></br>
                DOB : {customer.dateOfBirth}<br></br>
                Phone Number : {customer.phoneNumber}<br></br>
                Email : {customer.email}<br></br>
                Address : {customer.address}<br></br>
            </DialogContent>
        </Dialog>
    )
}
export default Modal;