package model;

import java.util.ArrayList;
import java.util.HashMap;

public class Product {
	private int productID;
	private int categoryID;
	private int branchID;
	private String gender;
	private String productName; 
	private String description;
	private float price;
	private int quantity;
	private int promotion;
	private String image;
	private String image2;
	private String image3;
	private String image4;
	
	public Product() {
		
	}

	public Product(int productID, int categoryID, int branchID, String gender, String productName, String description,
			float price, int quantity, int promotion, String image, String image2, String image3, String image4) {
		this.productID = productID;
		this.categoryID = categoryID;
		this.branchID = branchID;
		this.gender = gender;
		this.productName = productName;
		this.description = description;
		this.price = price;
		this.quantity = quantity;
		this.promotion = promotion;
		this.image = image;
		this.image2 = image2;
		this.image3 = image3;
		this.image4 = image4;
	}

	public int getProductID() {
		return productID;
	}

	public void setProductID(int productID) {
		this.productID = productID;
	}

	public int getCategoryID() {
		return categoryID;
	}

	public void setCategoryID(int categoryID) {
		this.categoryID = categoryID;
	}

	public int getBranchID() {
		return branchID;
	}

	public void setBranchID(int branchID) {
		this.branchID = branchID;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getProductName() {
		return productName;
	}

	public void setProductName(String productName) {
		this.productName = productName;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public float getPrice() {
		return price;
	}

	public void setPrice(float price) {
		this.price = price;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public int getPromotion() {
		return promotion;
	}

	public void setPromotion(int promotion) {
		this.promotion = promotion;
	}

	public String getImage() {
		return image;
	}

	public void setImage(String image) {
		this.image = image;
	}

	public String getImage2() {
		return image2;
	}

	public void setImage2(String image2) {
		this.image2 = image2;
	}

	public String getImage3() {
		return image3;
	}

	public void setImage3(String image3) {
		this.image3 = image3;
	}

	public String getImage4() {
		return image4;
	}

	public void setImage4(String image4) {
		this.image4 = image4;
	}

	public static void insert() {
		// TODO Auto-generated method stub
		
	}

	public void update() {
		// TODO Auto-generated method stub
		
	}

	public void delete() {
		// TODO Auto-generated method stub
		
	}	
}
