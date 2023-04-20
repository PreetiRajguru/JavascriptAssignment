import { useState } from "react";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import Grid from '@mui/material/Grid';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';


export const AddProductModal = ({ saveProduct, products, onClose, open }: any) => {
  const [productName, setProductName] = useState('');
  const [description, setDescription] = useState('');
  const [quantity, setQuantity] = useState('');
  const [price, setPrice] = useState('');
  const [activeStep, setActiveStep] = useState(0);


  const handleSaveProduct = () => {
    const newProduct = {
      id: products.length + 1,
      name: productName,
      description,
      quantity: parseInt(quantity),
      price: parseFloat(price),
    };
    saveProduct(newProduct);
    onClose(false);
    setProductName('');
    setDescription('');
    setQuantity('');
    setPrice('');
  };

  const handleNext = () => {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
  };
  const resetModalData = () => {
    onClose(false);
    setActiveStep(0);
    setProductName('');
    setDescription('');
    setQuantity('');
    setPrice('');
  };
  return (
    <Dialog open={open} onClose={resetModalData}>
      <DialogTitle>Add Product</DialogTitle>
      <DialogContent>
        <Stepper activeStep={activeStep} nonLinear>
          <Step>
            <StepLabel>Product Details</StepLabel>
          </Step>
          <Step>
            <StepLabel>Pricing Details</StepLabel>
          </Step>
        </Stepper>
        {activeStep === 1 ? (
          <>
            <Grid item xs={12} sm={12}>
              <TextField
                label="Quantity"
                fullWidth
                required
                value={quantity}
                onChange={(event) => setQuantity(event.target.value)}
                type="number"
                inputProps={{ min: 1 }}
              />
            </Grid>
            <TextField
              label="Price"
              fullWidth
              required
              value={price}
              onChange={(event) => setPrice(event.target.value)}
              type="number"
              inputProps={{ step: 0.01, min: 0 }}
            />
          </>
        ) : (
          <>
            <TextField
              label="Product Name"
              fullWidth
              required
              value={productName}
              onChange={(event) => setProductName(event.target.value)}
            />
            <TextField
              label="Description"
              fullWidth
              required
              value={description}
              onChange={(event) => setDescription(event.target.value)}
            />
          </>
        )}
      </DialogContent>
      <DialogActions>
        <Button onClick={resetModalData}>Cancel</Button>
        {activeStep === 1 ? (
          <Button onClick={handleSaveProduct} disabled={!quantity || !price}>
            Save
          </Button>
        ) : (
          <Button
            onClick={handleNext}
            disabled={!productName || !description}
          >
            Next
          </Button>
        )}
      </DialogActions>
    </Dialog>
  )
}