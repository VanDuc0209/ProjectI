package model;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

import connect.DBConnect;

public class Branch {

    private int branchID;
    private String branchName;

    public Branch() {
    	
    }

	public Branch(int branchID, String branchName) {
		super();
		this.branchID = branchID;
		this.branchName = branchName;
	}

	public int getBranchID() {
		return branchID;
	}

	public void setBranchID(int branchID) {
		this.branchID = branchID;
	}

	public String getBranchName() {
		return branchName;
	}

	public void setBranchName(String branchName) {
		this.branchName = branchName;
	}	
	
    // thêm mới dữ liệu
    public static boolean insertBranch(String branchName) {
        Connection connection = DBConnect.getConnection();
        String sql = "INSERT INTO Branch(branchName) VALUES('" + branchName + "')";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Branch.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    // cập nhật dữ liệu
    public static boolean updateBranch(Branch c) {
        Connection connection = DBConnect.getConnection();
        String sql = "UPDATE Branch SET branchName = ? WHERE branchID = ?";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            ps.setString(1, c.getBranchName());
            ps.setLong(2, c.getBranchID());
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Branch.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }

    // xóa dữ liệu
    public static boolean deleteBranch(int branchID) {
        Connection connection = DBConnect.getConnection();
        String sql = "DELETE FROM Branch WHERE branchID = ?";
        try {
            PreparedStatement ps = connection.prepareCall(sql);
            ps.setInt(1, branchID);
            return ps.executeUpdate() == 1;
        } catch (SQLException ex) {
            Logger.getLogger(Branch.class.getName()).log(Level.SEVERE, null, ex);
        }
        return false;
    }
	
    public static ArrayList<Branch> getListBranch() throws SQLException {
        Connection connection = DBConnect.getConnection();
        String sql = "SELECT * FROM Branch";
        PreparedStatement ps = connection.prepareCall(sql);
        ResultSet rs = ps.executeQuery();
        ArrayList<Branch> list = new ArrayList<>();
        while (rs.next()) {
            Branch branch = new Branch();
            branch.setBranchID(rs.getInt("branchID"));
            branch.setBranchName(rs.getString("branchName"));
            list.add(branch);
        }
        return list;
    }
    
	// get branch
    public static Branch getBranch(int branchID) throws SQLException {
        Connection connection = DBConnect.getConnection();
        String sql = "SELECT * FROM Branch WHERE branchID='" + branchID + "'";
        PreparedStatement ps = connection.prepareCall(sql);
        ResultSet rs = ps.executeQuery();
        Branch branch = new Branch();
        while (rs.next()) {
            branch.setBranchID(rs.getInt("branchID"));
            branch.setBranchName(rs.getString("branchName"));
        }
        return branch;
    }
}
