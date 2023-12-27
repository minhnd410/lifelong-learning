import { regtestUtils } from './_regtest'
import ECPairFactory from 'ecpair'
import * as ecc from 'tiny-secp256k1'
import * as bitcoin from 'bitcoinjs-lib'
import BitcoinJsonRpc from 'bitcoin-json-rpc';
import BIP32Factory from 'bip32';
import * as bip39 from 'bip39';

const bip32 = BIP32Factory(ecc);
const ECPair = ECPairFactory(ecc);
const network = regtestUtils.network;

// Native Segwit (P2WPKH)  (m/84'/0'/0'/0)
// Nested Segwit (P2SH-P2WPKH) (m/49/0/0/0/0)
// Taproot (P2TR) (m/86/0/0/0/0)
// Legacy (P2PKH) (m/44/0/0/0/0)


async function test_listUnspent() {
  var keyPair = ECPair.fromWIF("KxSpYkcYVVq93TB3ScP5WHSGUCjeNX5K52Vx9BjmxsBSkXuwDmpN")

  const p2wpkh = bitcoin.payments.p2wpkh({ pubkey: keyPair.publicKey, network })

  const rpc = new BitcoinJsonRpc('http://polaruser:polarpass@127.0.0.1:18446');

  const unspent = await rpc.listUnspent(6)

}

async function test_transfer_btc() {
  const keyPair = ECPair.makeRandom({ network });

  const p2pkh = bitcoin.payments.p2pkh({ pubkey: keyPair.publicKey, network })

  const unspent = await regtestUtils.faucet(p2pkh.address!, 2e4)

  // Get data of a certain transaction
  const fetchedTx = await regtestUtils.fetch(unspent.txId)

  // Mine 6 blocks, returns an Array of the block hashes
  // All of the above faucet payments will confirm
  const results = await regtestUtils.mine(6)

  const utx = await regtestUtils.fetch(unspent.txId);

  const psbt = new bitcoin.Psbt({ network })
  .addInput({
    hash: unspent.txId,
    index: unspent.vout,
    nonWitnessUtxo: Buffer.from(utx.txHex, 'hex'),
  })
  .addOutput({
    address: regtestUtils.RANDOM_ADDRESS,
    value: 2e4,
  });

  psbt.signInput(0, keyPair);

  regtestUtils.broadcast(
      psbt.finalizeAllInputs().extractTransaction().toHex(),
  )
}

async function test() {
  const seed = bip39.mnemonicToSeedSync("beyond laugh rich analyst gown worth oxygen primary play ivory final leader");
  const node = bip32.fromSeed(seed);
  const strng = node.toBase58();

  const root = bip32.fromSeed(seed);

  const child = root.derivePath("m/44'/0'/0'/0/0");

  var childAddr = bitcoin.payments.p2pkh({ pubkey: child.publicKey, network }).address!;
  var nodeAddr = bitcoin.payments.p2pkh({ pubkey: node.publicKey, network }).address!;
  const restored = bip32.fromBase58(strng);
  const strng2 = node.neutered().toBase58();

  // const node = bip32.fromSeed(seed);
  // const strng = node.toBase58();
  // const restored = bip32.fromBase58(strng);
}