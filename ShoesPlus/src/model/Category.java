package model;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

import connect.DBConnect;

public class Category {

    private int categoryID;
    private String categoryName;

    public Category() {
    	
    }

    public Category(int categoryID, String categoryName) {
        this.categoryID = categoryID;
        this.categoryName = categoryName;
    }

    public int getCategoryID() {
        return categoryID;
    }

    public void setCategoryID(int categoryID) {
        this.categoryID = categoryID;
    }

    public String getCategoryName() {
        return categoryName;
    }

    public void setCategoryName(String categoryName) {
        this.categoryName = categoryName;
    }

    // thêm mới dữ liệu
    public static boolean insertCategory(String categoryName) {
        Connection connection = DBConnect.getConnection();
        String sql = "INSERT INTO Category(categoryName) VALUES('" + categoryName + "')";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Category.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    // cập nhật dữ liệu
    public static boolean updateCategory(Category c) {
        Connection connection = DBConnect.getConnection();
        String sql = "UPDATE Category SET categoryName = ? WHERE categoryID = ?";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            ps.setString(1, c.getCategoryName());
            ps.setLong(2, c.getCategoryID());
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Category.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    // xóa dữ liệu
    public static boolean deleteCategory(int categoryID) {
        Connection connection = DBConnect.getConnection();
        String sql = "DELETE FROM Category WHERE categoryID = ?";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            ps.setInt(1, categoryID);
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Category.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }
	
    public static ArrayList<Category> getListCategory() throws SQLException {
        Connection connection = DBConnect.getConnection();
        String sql = "SELECT * FROM Category";
        PreparedStatement ps = connection.prepareCall(sql);
        ResultSet rs = ps.executeQuery();
        ArrayList<Category> list = new ArrayList<>();
        while (rs.next()) {
            Category category = new Category();
            category.setCategoryID(rs.getInt("categoryID"));
            category.setCategoryName(rs.getString("categoryName"));
            list.add(category);
        }
        return list;
    }
    
	// get category
    public static Category getCategory(int categoryID) throws SQLException {
        Connection connection = DBConnect.getConnection();
        String sql = "SELECT * FROM Category WHERE categoryID='" + categoryID + "'";
        PreparedStatement ps = connection.prepareCall(sql);
        ResultSet rs = ps.executeQuery();
        Category category = new Category();
        while (rs.next()) {
            category.setCategoryID(rs.getInt("categoryID"));
            category.setCategoryName(rs.getString("categoryName"));
        }
        return category;
    }
}
