-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 18, 2022 at 03:53 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_rawat_inap`
--

-- --------------------------------------------------------

--
-- Table structure for table `dokter`
--

CREATE TABLE `dokter` (
  `kode_dokter` text NOT NULL,
  `nama_dokter` text NOT NULL,
  `spesialis` text NOT NULL,
  `alamat` text NOT NULL,
  `telpon` text NOT NULL,
  `kode_poli` int(11) NOT NULL,
  `tarif` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dokter`
--

INSERT INTO `dokter` (`kode_dokter`, `nama_dokter`, `spesialis`, `alamat`, `telpon`, `kode_poli`, `tarif`) VALUES
('060001', 'Ruyanto Sambo', 'KULIT', 'Komplek Bhayangkari', '+6283617239', 0, '350000'),
('09002', 'Sony', 'KANDUNGAN', 'Rumah Berantah', '+6289102143', 1, '1300000');

-- --------------------------------------------------------

--
-- Table structure for table `kamar`
--

CREATE TABLE `kamar` (
  `kode_kamar` text NOT NULL,
  `nama_kamar` text NOT NULL,
  `jenis_kamar` text NOT NULL,
  `tarif` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kamar`
--

INSERT INTO `kamar` (`kode_kamar`, `nama_kamar`, `jenis_kamar`, `tarif`) VALUES
('ANGGREK03', 'ANGGREK', 'KELAS 3', '700000'),
('LAVENDER01', 'LAVENDER', 'VVIP', '1000000');

-- --------------------------------------------------------

--
-- Table structure for table `obat`
--

CREATE TABLE `obat` (
  `kode_obat` text NOT NULL,
  `nama_obat` text NOT NULL,
  `kategori_obat` text NOT NULL,
  `jenis` text NOT NULL,
  `harga` decimal(10,0) NOT NULL,
  `jumlah` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `obat`
--

INSERT INTO `obat` (`kode_obat`, `nama_obat`, `kategori_obat`, `jenis`, `harga`, `jumlah`) VALUES
('GIGI01', 'Catamflam', 'GIGI', 'Tablet', '45000', 1),
('OBGYN01', 'Kuretase', 'OBGYN', 'Cair', '1000000', 2);

-- --------------------------------------------------------

--
-- Table structure for table `pasien`
--

CREATE TABLE `pasien` (
  `kode_pasien` text NOT NULL,
  `nama_pasien` text NOT NULL,
  `alamat` text NOT NULL,
  `jenis_kelamin` text NOT NULL,
  `umur` int(11) NOT NULL,
  `telepon` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pasien`
--

INSERT INTO `pasien` (`kode_pasien`, `nama_pasien`, `alamat`, `jenis_kelamin`, `umur`, `telepon`) VALUES
('03061701', 'Nurkhotimah', 'Jl Nanggrek Raya', 'Wanita', 31, '+6289214242'),
('17092201', 'Fuad Maaruf', 'Trenggalek Timur', 'Pria', 11, '+6289128342'),
('17092202', 'Rudi Tambunan', 'Awaw', 'Pria', 21, '082108321');

-- --------------------------------------------------------

--
-- Table structure for table `pemakai`
--

CREATE TABLE `pemakai` (
  `kode_pemakai` int(11) NOT NULL,
  `username` text NOT NULL,
  `password` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pemakai`
--

INSERT INTO `pemakai` (`kode_pemakai`, `username`, `password`, `description`) VALUES
(1, 'admin', '1234', 'Administrator');

-- --------------------------------------------------------

--
-- Table structure for table `pendaftaran`
--

CREATE TABLE `pendaftaran` (
  `nomor_daftar` int(11) NOT NULL,
  `tanggal_daftar` text NOT NULL,
  `kode_dokter` text NOT NULL,
  `kode_pasien` text NOT NULL,
  `kode_poli` int(11) NOT NULL,
  `kode_pemakai` text NOT NULL,
  `biaya` decimal(10,0) NOT NULL,
  `ket` text NOT NULL,
  `nomor_antri` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pendaftaran`
--

INSERT INTO `pendaftaran` (`nomor_daftar`, `tanggal_daftar`, `kode_dokter`, `kode_pasien`, `kode_poli`, `kode_pemakai`, `biaya`, `ket`, `nomor_antri`) VALUES
(17, '0000-00-00', '060001', '03061701', 60001, 'Label4', '350000', '0', 1),
(17, '0000-00-00', '060001', '03061701', 60001, 'Label4', '350000', '0', 1),
(18, '17-09-2022', '060001', '060001', 60001, 'Label4', '350000', '0', 1),
(19, '17-09-2022', '', '', 0, 'Label4', '350000', '0', 1),
(20, '17-09-2022', '060001', '060001', 60001, 'Label4', '350000', '0', 1);

-- --------------------------------------------------------

--
-- Table structure for table `poli`
--

CREATE TABLE `poli` (
  `kode_poli` text NOT NULL,
  `nama_poli` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `poli`
--

INSERT INTO `poli` (`kode_poli`, `nama_poli`) VALUES
('01', 'KULIT'),
('02', 'OBGYN'),
('03', 'GIGI');

-- --------------------------------------------------------

--
-- Table structure for table `resep`
--

CREATE TABLE `resep` (
  `nomor_resep` text NOT NULL,
  `tanggal_resep` text NOT NULL,
  `kode_dokter` text NOT NULL,
  `kode_pasien` text NOT NULL,
  `kode_poli` text NOT NULL,
  `kode_pemakai` text NOT NULL,
  `total_harga` decimal(10,0) NOT NULL,
  `dibayar` decimal(10,0) NOT NULL,
  `kembali` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `resep`
--

INSERT INTO `resep` (`nomor_resep`, `tanggal_resep`, `kode_dokter`, `kode_pasien`, `kode_poli`, `kode_pemakai`, `total_harga`, `dibayar`, `kembali`) VALUES
('1706030001', '03/06/2017', '09002', '03061701', '01', '1', '117115', '120000', '2885');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `pemakai`
--
ALTER TABLE `pemakai`
  ADD PRIMARY KEY (`kode_pemakai`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
